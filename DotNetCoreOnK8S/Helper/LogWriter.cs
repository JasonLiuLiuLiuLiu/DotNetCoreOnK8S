using System;
using System.IO;
using System.Reflection;

namespace DotNetCoreOnK8S.Helper
{
    public class LogWriter
    {

        public static void Write(string logMessage)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using StreamWriter w = File.AppendText(path + "\\" + "log.txt");
            Log(logMessage, w);
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
            txtWriter.WriteLine("{0} {1}:{2}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString(), logMessage);
        }
    }
}