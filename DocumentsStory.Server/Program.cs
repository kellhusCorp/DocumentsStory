using System;
using System.Configuration;
using DocumentsStory.Contracts;
using DocumentsStory.Server.Services;
using System.ServiceModel;

namespace DocumentsStory.Server
{
    internal class Program
    {
        static void Main()
        {
            var uri = GetServiceUriFromConfig();
            var connectionString = GetConnectionStringFromConfig();
            IDocumentService documentService = new DocumentService(connectionString);
            ServiceHost host = new ServiceHost(documentService, uri);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IDocumentService), binding, string.Empty);
            host.Opened += HostOpened;
            host.Open();

            Console.ReadKey();
        }

        private static Uri GetServiceUriFromConfig()
        {
            var address = ConfigurationManager.AppSettings["hostAddress"];
            return new Uri(address);
        }

        private static string GetConnectionStringFromConfig(string connectionName = null)
        {
            return ConfigurationManager.ConnectionStrings[connectionName ?? "DefaultConnection"].ConnectionString;
        }

        private static void HostOpened(object sender, EventArgs e)
        {
            Console.WriteLine("Ожидаем запросы ...");
        }
    }
}
