using log4net.Config;
using log4net.Repository.Hierarchy;
using log4net;
using System.Reflection;
using System.Xml;

namespace CSharpFrameWork.Logs
{
    public class LogConfig
    {
        public static void LoadLog4NetConfig()
        {
            // Load Config
            var dataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\Logs\\log4net.config";

            var loggerRepo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(Hierarchy));

            var log4netConfig = new XmlDocument();
            var fs = File.OpenRead(dataPath);
            log4netConfig.Load(fs);

            XmlConfigurator.Configure(loggerRepo, log4netConfig["log4net"]);
        }
    }
}
