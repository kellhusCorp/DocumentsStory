using DocumentsStory.Contracts;
using DocumentsStory.Data.Contexts;
using DocumentsStory.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.ServiceModel;
using System.Threading.Tasks;

namespace DocumentsStory.Server.Services
{
    // Оставлю single, иначе для подачи connectionString, в режиме new ServiceHost(typeof(DocumentService), ....) придется делать как тут
    // https://stackoverflow.com/questions/2454850/how-do-i-pass-values-to-the-constructor-on-my-wcf-service/2455039#2455039
    /// <summary>
    /// Реализация <see cref="IDocumentService"/>
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DocumentService : IDocumentService
    {
        private readonly string connectionString;

        /// <summary>
        /// Создает инстанс сервиса.
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД.</param>
        public DocumentService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<Document>> GetDocuments()
        {
            using (var context = new MainContext(connectionString))
            {
                return await context.Documents
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
