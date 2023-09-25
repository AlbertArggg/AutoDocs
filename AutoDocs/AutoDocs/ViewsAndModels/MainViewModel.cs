using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDocs.Resources.ResourceManager;

namespace AutoDocs
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _directory;
        private ResourceManager _resourceManager;

        public MainViewModel()
        {
            _resourceManager = new ResourceManager();
        }

        public string Directory
        {
            get { return _directory; }
            set
            {
                _directory = value;
                OnPropertyChanged(nameof(Directory));
                OnPropertyChanged(nameof(IsDirectoryValid));
            }
        }

        public bool IsDirectoryValid
        {
            get { return DirectoryExists(Directory); }
        }

        private bool DirectoryExists(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TitleImageDirectory { get { return _resourceManager.GetTitleImageDirectory(); } }
        public string LogoImageDirectory { get { return _resourceManager.GetLogoImageDirectory(); } }
    }
}
