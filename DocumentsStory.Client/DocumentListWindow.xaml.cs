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
        public readonly DocumentListViewModel ViewModel;

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
        private static IDocumentService GetDocumentClient(string hostAddress = null)
        {
            return new DocumentClient(hostAddress ?? ConfigurationManager.AppSettings["hostAddress"]);
        }

        private void ClearDataGridItems()
        {
            documentsGrid.Items.Clear();
        }
    }
}