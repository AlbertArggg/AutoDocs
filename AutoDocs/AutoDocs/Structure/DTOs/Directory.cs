using System.Collections.Generic;
using System.IO;
using System.Text;

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

        /*
        public string GenerateDirectoryHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"directory-container\">");
    
            sb.AppendLine("<div class=\"title-container\">");
            sb.AppendFormat($"<img src=\"{Icon}\" alt=\"Directory Icon\" width=\"30px\", height=\"30px\" class=\"directory-icon\">\n");
            sb.AppendFormat($"<span class=\"directory-name\">{DirectoryName}</span>\n");
            sb.AppendLine("</div>");

            sb.AppendLine("<div class=\"directory-info-container\">");
            sb.AppendFormat($"<p><strong>Path: </strong> {Path} </p>\n");
            sb.AppendLine("</div>");

            if (Directories.Count > 0)
            {
                sb.AppendLine("<div class=\"nested-directories\">");
                sb.AppendLine("<p><strong>Nested Directories: </strong></p>");
                foreach(Directory dir in Directories)
                {
                    sb.AppendLine(dir.GenerateDirectoryHTML());
                }
                sb.AppendLine("    </div>");   
            }

            if (Files.Count > 0)
            {
                sb.AppendLine("    <div class=\"nested-files\">");
                sb.AppendLine("        <p><strong>Nested Files: </strong></p>");
                foreach(File file in Files)
                {
                    sb.AppendLine(file.GenerateFileHtml());
                }
                sb.AppendLine("    </div>");
            }

            if (Classes.Count > 0)
            {
                sb.AppendLine("    <div class=\"nested-classes\">");
                sb.AppendLine("        <p><strong>Nested Classes: </strong></p>");
                foreach(Class cls in Classes)
                {
                    sb.AppendLine(cls.GenerateClassHtml());
                }
                sb.AppendLine("    </div>");
            }
            
            sb.AppendLine("</div>");
            return sb.ToString();
        }
        */
        
        public string GenerateDirectoryHTML()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<details open>");
            sb.AppendLine("<summary>");
            sb.AppendFormat($"<img src=\"{Icon}\" alt=\"Directory Icon\" width=\"30px\", height=\"30px\" class=\"directory-icon\"> ");
            sb.AppendFormat($"<span class=\"directory-name\">{DirectoryName}</span>");
            sb.AppendLine("</summary>");

            sb.AppendLine("<ul>");

            foreach (Directory dir in Directories)
            {
                sb.AppendLine("<li>");
                sb.AppendLine(dir.GenerateDirectoryHTML());
                sb.AppendLine("</li>");
            }

            foreach (File file in Files)
            {
                sb.AppendLine("<li>");
                sb.AppendFormat($"<img src=\"{file.Icon}\" alt=\"File Icon\" width=\"30px\", height=\"30px\" class=\"file-icon\"> ");
                sb.AppendLine($"<span class=\"file-name\">{file.FileDisplayName}</span>");
                sb.AppendLine("</li>");
            }

            foreach (Class cls in Classes)
            {
                sb.AppendLine("<li>");
                sb.AppendFormat($"<img src=\"{cls.ClassIcon}\" alt=\"Class Icon\" width=\"30px\", height=\"30px\" class=\"class-icon\"> ");
                sb.AppendLine($"<a href=\"{cls.ClassName}.html\" class=\"class-name\">{cls.ClassDisplayName}</a>");
                cls.BuildClassHtmlFile();
                sb.AppendLine("</li>");
            }

            sb.AppendLine("</ul>");
            sb.AppendLine("</details>");

            return sb.ToString();
        }
    }
}