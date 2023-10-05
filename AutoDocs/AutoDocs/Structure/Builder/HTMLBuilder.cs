using System.Text;
using AutoDocs.Structure.DTOs;

namespace AutoDocs.Structure.Builder
{
    public class HTMLBuilder
    {
        public static string GenerateIndexHtml(Directory _mainDirectory)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"en\">");

            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"UTF-8\">");
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sb.AppendLine("<title>Main Directory</title>");
            sb.AppendLine("<link rel=\"stylesheet\" href=\"StylesAndScripts\\main-list-style.css\">");
            sb.AppendLine("</head>");

            sb.AppendLine("<body>");
            sb.AppendLine(_mainDirectory.GenerateDirectoryHTML());
            
            sb.AppendLine("<script src=\"https://code.jquery.com/jquery-3.6.0.min.js\"></script>");
            
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
        
        public static string GenerateClassHTML(Class cls)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"en\">");

            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"UTF-8\">");
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sb.AppendLine($"<title>{cls.ClassDisplayName}</title>");
            sb.AppendLine("<link rel=\"stylesheet\" href=\"StylesAndScripts\\styles.css\">");
            sb.AppendLine("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/highlight.js/10.7.2/highlight.min.js\"></script>");
            sb.AppendLine("</head>");

            sb.AppendLine("<body>");
            sb.AppendLine(cls.GenerateClassHtml());
            
            // Scripts
            sb.AppendLine("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/highlight.js/10.7.2/highlight.min.js\"></script>");
            sb.AppendLine("<script src=\"StylesAndScripts\\script.js\"></script>");

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}