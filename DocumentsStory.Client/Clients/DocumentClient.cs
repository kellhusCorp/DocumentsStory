using DocumentsStory.Contracts;
using DocumentsStory.Domain;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DocumentsStory.Client.Clients
{
    /// <summary>
    /// Клиент для работы с документами.
    /// </summary>
    public class DocumentClient : IDocumentService
    {
        private readonly string hostAddress;

        public DocumentClient(string hostAddress)
        {
            this.hostAddress = hostAddress;
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            var binding = new NetTcpBinding(SecurityMode.None);
            var channelFactory = new ChannelFactory<IDocumentService>(binding);
            var endpoint = new EndpointAddress(hostAddress);

            try
            {
                var proxy = channelFactory.CreateChannel(endpoint);
                var docs = await proxy?.GetDocuments();
                channelFactory.Close();
                return docs;
            }
            catch
            {
                channelFactory.Abort();
                throw;
            }
        }
    }
}