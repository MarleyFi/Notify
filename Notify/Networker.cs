using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Notify.Properties;

namespace Notify
{
    internal class Networker
    {
        private static DataStore dataStore = FrmNotify.dataStore;

        /// <summary>
        /// Feuert den Konfigurierten Request
        /// </summary>
        /// <param name="title">Titel des POSTs</param>
        /// <param name="body">Textkörper des POSTs</param>
        /// <param name="htmlEnabled">HTML Aktivieren/Deaktivieren</param>
        /// <param name="variablesEnabled">Variablen Aktivieren/Deaktivieren</param>
        /// <param name="tokenIndex">Index des ausgewählten Tokens</param>
        /// <param name="tokenEnabled">Ausgewählter Token/Standard-Token</param>
        /// <param name="priorityIndex">Index der ausgewählten Priorität</param>
        /// <param name="priorityEnabled">Ausgewählte Priorität/Standard-Priorität</param>
        public static bool FireRequest(string title, string body, bool htmlEnabled, bool variablesEnabled, int tokenIndex, bool tokenEnabled, int priorityIndex, bool priorityEnabled)
        {
            string calculatedUser = dataStore.UserToken;
            string calculatedTitle = variablesEnabled ? Supporter.FormatText(title) : title;
            string calculatedBody = variablesEnabled ? Supporter.FormatText(body) : body;
            string calculatedToken = tokenEnabled ? dataStore.GetTokenByIndex(tokenIndex) : dataStore.GetDefaultToken();
            string calculatedPriority = priorityEnabled ? dataStore.GetPriority(priorityIndex) : "0";
            string calculatedHtml = htmlEnabled ? "1" : "0";
            string calculatedTimestamp = Supporter.GetUnixTimestamp(TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime()).Hours).ToString();
            string jsonString;
            byte[] jsonBytes;
            RequestDAO response = new RequestDAO();

            var parameters = new NameValueCollection // Building components...
            {
            { "user", calculatedUser },
            { "title", calculatedTitle },
            { "message", calculatedBody },
            { "token", calculatedToken },
            { "priority", calculatedPriority },
            { "html", calculatedHtml },
            { "timestamp", calculatedTimestamp },
            };
            
            try
            {
                
                using (var client = new WebClient())
                {
                    //client.UploadValuesCompleted += Client_UploadValuesCompleted; // sending...
                    //client.UploadValuesAsync(new Uri("https://api.pushover.net/1/messages.json"), parameters);
                    jsonBytes = client.UploadValues(new Uri("https://api.pushover.net/1/messages.json"), parameters);
                    jsonString = Encoding.ASCII.GetString(jsonBytes);
                    response = JsonConvert.DeserializeObject<RequestDAO>(jsonString);
                    dataStore.LogTransaction(calculatedTitle, calculatedBody, calculatedUser, tokenIndex, priorityIndex, response.request); // logging...
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong...\r\n" + e.Message, "Error while request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RequestErrorProvider(e.Message);
                return false;
            }
            
            return response.GetStatus();
        }

        /// <summary>
        /// Feuert den Vordefinierten Request
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="html"></param>
        /// <param name="tokenIndex"></param>
        /// <param name="priorityIndex"></param>
        /// <param name="counter"></param>
        public static bool FireAutomatedRequest(string title, string body, bool htmlEnabled, bool variablesEnabled, int tokenIndex, int priorityIndex, int counter = 0)
        {
            string calculatedUser = dataStore.UserToken;
            string calculatedTitle = variablesEnabled ? Supporter.FormatText(title) : title;
            string calculatedBody = variablesEnabled ? Supporter.FormatText(body) : body;
            string calculatedToken = dataStore.GetTokenByIndex(tokenIndex);
            string calculatedPriority = dataStore.GetPriority(priorityIndex);
            string calculatedHtml = htmlEnabled ? "1" : "0";
            string calculatedTimestamp = Supporter.GetUnixTimestamp(TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime()).Hours).ToString();
            string jsonString;
            byte[] jsonBytes;
            RequestDAO response = new RequestDAO();

            var parameters = new NameValueCollection
            {
            { "user", calculatedUser },
            { "title", calculatedTitle },
            { "message", calculatedBody },
            { "token", calculatedToken },
            { "priority", calculatedPriority },
            { "html", calculatedHtml },
            { "timestamp", calculatedTimestamp },
            };

            try
            {
                using (var client = new WebClient())
                {
                    jsonBytes = client.UploadValues(new Uri("https://api.pushover.net/1/messages.json"), parameters);
                    jsonString = Encoding.ASCII.GetString(jsonBytes);
                    response = JsonConvert.DeserializeObject<RequestDAO>(jsonString);
                    dataStore.LogTransaction(calculatedTitle, calculatedBody, calculatedUser, tokenIndex, priorityIndex, response.request); // logging...
                }
            }
            catch (Exception e)
            {
                //labelProgress.Text = "Transfer error";
                MessageBox.Show("Something went wrong...\r\n" + e.Message, "Error while request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RequestErrorProvider(e.Message);
                return response.GetStatus();
            }
            return response.GetStatus();
        }

        /// <summary>
        /// Lädt die angegebene Datei aus dem Internet herunter
        /// </summary>
        /// <param name="counterArg">Counter argument.</param>
        public static void DownloadFile(int counterArg = 0, bool startUp = true)
        {
            int counter = counterArg;
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFile(new Uri(Settings.Default.fileURL), Settings.Default.filePath);

                    //byte[] response = webClient.DownloadData(Settings.Default.fileURL); // ToDo: Async && one Download
                    //string jsonString = Encoding.ASCII.GetString(response);
                    //object dao = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenDAO>(jsonString);
                }
                catch (Exception ex)
                {
                    if (counter == 2)
                    {
                        if (startUp)
                        {
                            FrmNotify.dataStore.WebExceptionDialog();
                        }
                    }
                    else
                    {
                        dataStore.CheckFiles();
                        DownloadFile(counter + 1, startUp);
                    }
                }
            }
        }

        public static TokenListDAO GetTokens(string url)
        {
            //List<TokenDAO> token = new List<TokenDAO>();
            Uri host = new Uri(url);
            TokenListDAO response = new TokenListDAO();
            try
            {
                using (var client = new WebClient())
                {
                    byte[] jsonBytes = client.DownloadData(host);
                    string jsonString = Encoding.ASCII.GetString(jsonBytes);
                        try
                        {
                            response = JsonConvert.DeserializeObject<TokenListDAO>(jsonString);
                            dataStore.TokenJSONList = response;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return response;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="exception"></param>
        public static void RequestErrorProvider(string exception)
        {
            if (exception.Contains("400")) // UserToken
            {
                dataStore.HelpUser(3);
            }
        }

        public static bool CheckFileURL(string url)
        {
            using (WebClient webClientCheckFileURL = new WebClient())
            {
                try
                {
                    byte[] response = webClientCheckFileURL.DownloadData(new Uri(Settings.Default.fileURL));
                    string jsonString = Encoding.ASCII.GetString(response);

                    if ((jsonString != string.Empty && !string.IsNullOrWhiteSpace(jsonString) && jsonString.Contains("<head>") || jsonString.Contains("<script>") || jsonString.Contains("</head>") || jsonString.Contains("</script>")) && !Settings.Default.SettingUseLocalFile)
                    {
                        FrmNotify.dataStore.IsFileURLValid = false;
                        return false;
                    }
                    FrmNotify.dataStore.IsFileURLValid = true;
                    return true;
                }
                catch (Exception ex)
                {
                    if (CheckConnectionByPing())
                    {
                        FrmNotify.NotifyIcon.ShowBalloonTip(500, "Error while FileURL-Respond-Test", ex.Message, ToolTipIcon.Error);
                        FrmNotify.dataStore.IsFileURLValid = false;
                    }
                    else
                    {
                        FrmNotify.NotifyIcon.ShowBalloonTip(500, "No connection", ex.InnerException.Message, ToolTipIcon.Error);
                    }
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static bool CheckConnectionByPing(string host = "google.com")
        {
            try
            {
                Ping checkConnectionByPing = new Ping();
                byte[] buffer = new byte[32];
                int timeout = 500;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = checkConnectionByPing.Send(host, timeout, buffer, pingOptions);
                FrmNotify.dataStore.HasInternetConnection = (reply.Status == IPStatus.Success);
                FrmNotify.dataStore.PingLatency = reply.RoundtripTime;
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                FrmNotify.dataStore.PingLatency = 10000;
                FrmNotify.dataStore.HasInternetConnection = false;
                return false;
                // No InternetConnection
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static long CheckConnectionByPingLatency(string host = "google.com")
        {
            try
            {
                Ping checkConnectionByPingLatency = new Ping();
                byte[] buffer = new byte[32];
                int timeout = 500;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = checkConnectionByPingLatency.Send(host, timeout, buffer, pingOptions);
                FrmNotify.dataStore.HasInternetConnection = (reply.Status == IPStatus.Success);
                FrmNotify.dataStore.PingLatency = reply.RoundtripTime;
                return reply.RoundtripTime;
            }
            catch (Exception)
            {
                FrmNotify.dataStore.PingLatency = 10000;
                FrmNotify.dataStore.HasInternetConnection = false;
                return 10000;
                // No InternetConnection
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="host"></param>
        /// <param name="echoNum"></param>
        /// <returns></returns>
        public static double CheckConnectionByPingLatencyAverage(int echoNum, string host = "google.com")
        {
            try
            {
                long totalTime = 0;
                int timeout = 500;
                Ping checkConnectionByPingLatencyAverage = new Ping();
                for (int i = 0; i < echoNum; i++)
                {
                    PingReply reply = checkConnectionByPingLatencyAverage.Send(host, timeout);
                    if (reply.Status == IPStatus.Success)
                    {
                        totalTime += reply.RoundtripTime;
                    }
                    else
                    {
                        return 10000;
                    }
                }
                return (totalTime / echoNum);
            }
            catch (Exception)
            {
                return 10000.0;
                // No InternetConnection
            }
        }
    }
}