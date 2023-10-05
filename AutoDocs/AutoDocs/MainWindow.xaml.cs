using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using AutoDocs.Resources.ResourceManager;
using AutoDocs.Structure.Builder;
using Directory = AutoDocs.Structure.DTOs.Directory;
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
            
            var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OutputHTML");
            if (!System.IO.Directory.Exists(outputPath))
            {
                System.IO.Directory.CreateDirectory(outputPath);
            }
            
            var filePath = Path.Combine(outputPath, "index.html");
            System.IO.File.WriteAllText(filePath, HTMLBuilder.GenerateIndexHtml(MainDirectory));
            Process.Start(filePath);
        }
    }
}