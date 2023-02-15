using DocumentsStory.Client.ViewModels;
using System.Windows;

namespace DocumentsStory.Client
{

    public partial class DocumentListWindow : Window
    {
        public DocumentListViewModel ViewModel;

        public DocumentListWindow()
        {
            InitializeComponent();
            ClearDataGridItems();
            ViewModel = new DocumentListViewModel();
            DataContext = ViewModel;
        }

        private void ClearDataGridItems()
        {
            documentsGrid.Items.Clear();
        }
    }
}
