using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notify.Properties;

namespace Notify
{
    class Exporter
    {

        static DataStore dataStore = FrmNotify.dataStore;

        public static void ExportToBatch()
        {
            const string path = @"C:\Users\maf\Desktop\temp\Notify\command.cmd";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                File.WriteAllText(path, string.Empty);
            }
            List<string> command = new List<string>();
            command.Add(@"curl -s \");
            command.Add(@"  --cacert ca-bundle.crt \");
            command.Add(string.Format(@"  --form-string 'token = {0}' \", dataStore.GetTokenByIndex(Settings.Default.defaultToken)));
            command.Add(string.Format(@"  --form-string 'user = {0}' ' \", dataStore.UserToken));
            command.Add(string.Format(@"  --form-string 'message = {0}' \", Settings.Default.defaultBody));
            command.Add("https://api.pushover.net/1/messages.json");

            char character = (char)34;

            for (int i = 2; i <= 4; i++)
            {
                command[i] = command[i].Replace("'", character.ToString());
            }
            File.WriteAllLines(path, command);
        }

        public static void ExportToShell()
        {
            const string path = @"C:\Users\maf\Desktop\temp\Notify\command.cmd";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                File.WriteAllText(path, string.Empty);
            }
            List<string> command = new List<string>();
            command.Add(@"$uri = 'https://api.pushover.net/1/messages.json'");
            command.Add(@"$parameters = @{");
            command.Add(string.Format(@"token = '{0}'", dataStore.GetTokenByIndex(Settings.Default.defaultToken)));
            command.Add(string.Format(@"user = '{0}'", dataStore.UserToken));
            command.Add(string.Format(@"message = '{0}'", Settings.Default.defaultBody));
            command.Add("}");
            command.Add("$parameters | Invoke-RestMethod -Uri $uri -Method Post");

            char character = (char)34;

            for (int i = 0; i <= command.Count - 1; i++)
            {
                command[i] = command[i].Replace("'", character.ToString());
            }
            File.WriteAllLines(path, command);
        }
    }
}
