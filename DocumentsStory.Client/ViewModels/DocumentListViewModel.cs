using DocumentsStory.Client.Helpers;
using DocumentsStory.Contracts;
using DocumentsStory.Domain;
using System.Collections.Generic;

namespace DocumentsStory.Client.ViewModels
{
    /// <summary>
    /// VM для списка документов.
    /// </summary>
    public class DocumentListViewModel
    {
        /// <summary>
        /// Создает инстанс VM.
        /// </summary>
        /// <param name="documentService">Поставщик документов.</param>
        public DocumentListViewModel(IDocumentService documentService)
        {
            Documents = new NotifyTaskCompletion<IEnumerable<Document>>(documentService.GetDocuments());
        }

        public NotifyTaskCompletion<IEnumerable<Document>> Documents { get; private set; }
    }
}
