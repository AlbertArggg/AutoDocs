using System;
using System.Windows;
using System.Windows.Forms;
using AutoDocs.Resources.ResourceManager;

namespace AutoDocs
{
    public partial class MainWindow
    {
        private ResourceManager _resourceManager;
        public string TitleImageDir;
        public string LogoImageDir;

        public MainWindow()
        {
            _resourceManager = new ResourceManager();
            TitleImageDir = TitleImageDirectory;
            LogoImageDir = LogoImageDirectory;
            this.DataContext = this;
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
                    System.Windows.MessageBox.Show($"You selected: {selectedFolder}");
                }
            }
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    System.Windows.MessageBox.Show($"You selected: {selectedFolder}");
                }
            }
        }

        public string TitleImageDirectory
        {
            get 
            {
                string TitleDir = _resourceManager.GetTitleImageDirectory();
                Console.WriteLine(TitleDir);
                return _resourceManager.GetTitleImageDirectory(); 
            }
        }

        public string LogoImageDirectory
        {
            get 
            {
                string LogoDir = _resourceManager.GetLogoImageDirectory();
                Console.WriteLine(LogoDir); 
                return _resourceManager.GetLogoImageDirectory(); 
            }
        }
    }
}