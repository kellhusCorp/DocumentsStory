using DocumentsStory.Client.Clients;
using DocumentsStory.Client.ViewModels;
using DocumentsStory.Contracts;
using System.Configuration;
using System.Windows;

namespace DocumentsStory.Client
{
    /// <summary>
    /// Страница для отображения списка документов.
    /// </summary>
    public partial class DocumentListWindow : Window
    {
        /// <summary>
        /// VM.
        /// </summary>
        public DocumentListViewModel ViewModel;

        public DocumentListWindow()
        {
            InitializeComponent();
            ClearDataGridItems();
            var client = GetDocumentClient();
            ViewModel = new DocumentListViewModel(client);
            DataContext = ViewModel;
        }

        /// <summary>
        /// Возвращает инстанс поставщика документов.
        /// <para>Если <b>hostAddress</b> не задан, адрес возьмется из конфига текущего приложения.</para>
        /// </summary>
        /// <param name="hostAddress">Адрес сервера.</param>
        /// <returns></returns>
        private IDocumentService GetDocumentClient(string hostAddress = null)
        {
            var client = new DocumentClient(hostAddress ?? ConfigurationManager.AppSettings["hostAddress"]);
            return client;
        }

        private void ClearDataGridItems()
        {
            documentsGrid.Items.Clear();
        }
    }
}
