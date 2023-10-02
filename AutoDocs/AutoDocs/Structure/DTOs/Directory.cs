using System.Collections.Generic;
using System.IO;

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
        
        public override string ToString()
        {
            using (StringWriter writer = new StringWriter())
            {
                AppendToString(writer, 0);
                return writer.ToString();
            }
        }

        private void AppendToString(StringWriter writer, int indentLevel)
        {
            var indent = new string('\t', indentLevel);
            writer.WriteLine($"{indent}Directory Name: {DirectoryName}");
            writer.WriteLine($"{indent}Path: {Path}");
            writer.WriteLine($"{indent}Icon: {Icon}");
            
            
            if (Directories != null && Directories.Count>0)
            {
                writer.WriteLine($"{indent}Sub-directories:");
                foreach (var dir in Directories)
                {
                    writer.WriteLine($"{indent}\t{dir.DirectoryName} at {dir.Path}");
                    dir.AppendToString(writer, indentLevel + 1);
                }
            }

            if (Classes != null && Classes.Count>0)
            {
                writer.WriteLine($"{indent}Classes:");
                foreach (var cls in Classes)
                {
                    writer.WriteLine($"\t{cls}");
                }
            }

            if (Files != null && Files.Count>0)
            {
                writer.WriteLine($"{indent}Files:");
                foreach (var file in Files)
                {
                    writer.WriteLine($"{indent}\t{file.FileName} at {file.FileDirectory}");
                }
            }
        }
    }
}