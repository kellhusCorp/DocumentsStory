using System;
using System.Configuration;
using DocumentsStory.Contracts;
using DocumentsStory.Server.Services;
using System.ServiceModel;

namespace DocumentsStory.Server
{
    internal static class Program
    {
        private static void Main()
        {
            var uri = GetServiceUriFromConfig();
            var connectionString = GetConnectionStringFromConfig();
            IDocumentService documentService = new DocumentService(connectionString);
            var host = new ServiceHost(documentService, uri);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IDocumentService), binding, string.Empty);
            host.Opened += HostOpened;
            host.Open();

            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает <see cref="Uri"/> на основе узла, указанного в конфиге приложения.
        /// </summary>
        /// <returns></returns>
        private static Uri GetServiceUriFromConfig()
        {
            var address = ConfigurationManager.AppSettings["hostAddress"];
            return new Uri(address);
        }

        /// <summary>
        /// Возвращает строку подключения из конфига текущего приложения.
        /// <para>Если <b>connectionName</b> не задан, то используется DefaultConnection.</para>
        /// </summary>
        /// <param name="connectionName">Название строки подключения.</param>
        /// <returns></returns>
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