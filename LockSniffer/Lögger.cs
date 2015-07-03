using System;
using System.Configuration;
using System.IO;

namespace LockSniffer
{
    public class Lögger
    {
        public static string GetPath()
        {
            return Environment.ExpandEnvironmentVariables(ConfigurationManager.AppSettings["Path"]);
        }

        public void Lög(LögEntry l)
        {
            File.AppendAllText(GetPath(), l.Serialize());
        }
    }
}