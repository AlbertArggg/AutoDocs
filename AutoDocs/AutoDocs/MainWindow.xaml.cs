using System;
using System.Windows;
using System.Windows.Forms;

namespace AutoDocs
{
    public partial class MainWindow
    {
        public MainWindow()
        {
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
                    Console.WriteLine($"Selected Folder: {selectedFolder}");
                    System.Windows.MessageBox.Show($"You selected: {selectedFolder}");
                }
            }
        }
    }
}