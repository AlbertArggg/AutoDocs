using System.Text;
using AutoDocs.ExtensionMethods;

namespace AutoDocs.Structure.DTOs
{
    public class File
    {
        public string FileName { get; private set; }
        public string FileDisplayName;
        public string FileDirectory { get; private set; }
        public string Icon { get; private set; }

        public File(string _name, string _dir, string _icon)
        {
            FileName = _name;
            FileDisplayName = _name.SplitOnUpperCase();
            FileDirectory = _dir;
            Icon = _icon;
        }
        
        public string GenerateFileHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"file-container\">");
            sb.AppendLine("<div class=\"title-container\">");
            sb.AppendFormat($"<img src=\"{Icon}\" alt=\"File Icon\" class=\"file-icon\">\n");
            sb.AppendFormat($"<span class=\"file-name\">{FileDisplayName}</span>\n");
            sb.AppendLine("</div>");
            sb.AppendLine("<div class=\"file-info-container\">");
            sb.AppendFormat($"<p><Strong>File Name: </Strong> {FileName} </p>\n");
            sb.AppendFormat($"<p><Strong>File Directory: </Strong> {FileDirectory} </p>\n");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }
    }
}