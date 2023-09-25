using System.Windows;
using System.Windows.Forms;
using AutoDocs.Resources.ResourceManager;

namespace AutoDocs
{
    public partial class MainWindow
    {
        private ResourceManager _resourceManager;

        public MainWindow()
        {
            _resourceManager = new ResourceManager();
            this.DataContext = new MainViewModel();

            InitializeComponent();
        }
        private void btnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    txtDirectory.Text = selectedFolder;
                }
            }
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            // launch application
        }
    }
}