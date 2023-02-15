using DocumentsStory.Contracts;
using DocumentsStory.Domain;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DocumentsStory.Client.Helpers
{
    public class DocumentsGetter
    {
        private readonly string hostAddress = ConfigurationManager.AppSettings["hostAddress"];

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
