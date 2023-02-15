using DocumentsStory.Domain;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DocumentsStory.Contracts
{
    /// <summary>
    /// Описывает работу с документами.
    /// </summary>
    [ServiceContract]
    public interface IDocumentService
    {
        /// <summary>
        /// Возвращает список документов.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task<IEnumerable<Document>> GetDocuments();
    }
}
