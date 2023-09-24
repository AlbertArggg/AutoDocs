using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoDocs.Resources.ResourceManager
{
    public class ResourceManager
    {
        public class Resource
        {
            public string ResourceName { get; private set; }
            public string ResourceDirectory { get; private set; }

            public Resource(string _name, string _directory)
            {
                ResourceName = _name;
                ResourceDirectory = _directory;
            }
        }

        private List<Resource> Resources = new List<Resource>();
        
        
        public static ResourceManager Instance { get; } = new ResourceManager();

        public ResourceManager()
        {
            InitializeResourcePaths();
        }

        private void InitializeResourcePaths()
        {
            Resources.Add(new Resource("Base Directory", AppDomain.CurrentDomain.BaseDirectory));
            Resources.Add(new Resource("Title Image", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Autodoc_Title.png")));
            //Resources.Add(new Resource("Title Image", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "D:\\GithubRepos\\AutoDocs\\AutoDocs\\AutoDocs\\bin\\Debug\\Resources\\Images\\Autodoc_Title.png")));
            Resources.Add(new Resource("Logo Image", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "Autodoc_Logo.png")));
            //Resources.Add(new Resource("Logo Image", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "D:\\GithubRepos\\AutoDocs\\AutoDocs\\AutoDocs\\bin\\Debug\\Resources\\Images\\Autodoc_Logo.png")));
        }

        public string GetBaseDirectory()
        {
            Resource resource = Resources.FirstOrDefault(r => r.ResourceName == "Base Directory");
            return resource?.ResourceDirectory;
        }

        public string GetTitleImageDirectory()
        {
            Resource resource = Resources.FirstOrDefault(r => r.ResourceName == "Title Image");
            return resource?.ResourceDirectory;
        }

        public string GetLogoImageDirectory()
        {
            Resource resource = Resources.FirstOrDefault(r => r.ResourceName == "Logo Image");
            return resource?.ResourceDirectory;
        }
    }
}