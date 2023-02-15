using DocumentsStory.Client.Helpers;
using DocumentsStory.Domain;
using System.Collections.Generic;

namespace DocumentsStory.Client.ViewModels
{
    public class DocumentListViewModel
    {
        public DocumentListViewModel()
        {
            Documents = new NotifyTaskCompletion<IEnumerable<Document>>(new DocumentsGetter().GetDocuments());
        }

        public NotifyTaskCompletion<IEnumerable<Document>> Documents { get; private set; }
    }
}
