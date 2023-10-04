using System.Text;
using AutoDocs.ExtensionMethods;

namespace AutoDocs.Structure.DTOs
{
    public class Parameter
    {
        public string ParameterName;
        public string ParameterType;
        public string ParameterDisplayName;

        public Parameter(string _name, string _type)
        {
            ParameterName = _name;
            ParameterType = _type;
            ParameterDisplayName = _name.SplitOnUpperCase();
        }

        public string GenerateParameterHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<tr>");
            sb.AppendLine($"<td>{ParameterDisplayName}</td>");
            sb.AppendLine($"<td>{ParameterName}</td>");
            sb.AppendLine($"<td>{ParameterType}</td>");
            sb.AppendLine("</tr>");
            return sb.ToString();
        }
    }
}