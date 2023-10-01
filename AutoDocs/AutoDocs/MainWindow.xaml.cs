using System.Windows;
using System.Windows.Forms;
using AutoDocs.Resources.ResourceManager;
using AutoDocs.Structure.Builder;
using AutoDocs.Structure.DTOs;
using File = System.IO.File;

namespace AutoDocs
{
    public partial class MainWindow
    {
        public MainWindow()
        {
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
            Directory MainDirectory = Builder.BuildCodeStructure(txtDirectory.Text);
            File.WriteAllText("output.txt", MainDirectory.ToString());
        }
    }
}