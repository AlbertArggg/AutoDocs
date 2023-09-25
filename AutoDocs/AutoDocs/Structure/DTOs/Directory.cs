using System.Collections.Generic;

namespace AutoDocs.Structure.DTOs
{
    public class Directory
    {
        public string DirectoryName { get; private set; }
        public string Path { get; private set; }
        public string Icon { get; private set; }
        
        public List<Directory> Directories {get; set;}
        public List<Class> Classes {get; set;}
        public List<File> Files { get; set; }

        public Directory(string _name, string _path, string _icon, List<Directory> _directories, List<Class> _classes, List<File> _files)
        {
            DirectoryName = _name;
            Path = _path;
            Icon = _icon;
            Directories = _directories;
            Classes = _classes;
            Files = _files;
        }
    }
}