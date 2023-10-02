using System.Text;
using AutoDocs.ExtensionMethods;

namespace AutoDocs.Structure.DTOs
{
    public class Variable
    {
        public string VariableName;
        public string VariableType;
        public string AccessModifier;
        public string DisplayName;
        
        public Variable(string _name, string _type, string _accMod)
        {
            VariableName = _name;
            VariableType = _type;
            AccessModifier = _accMod;
            DisplayName = _name.SplitOnUpperCase();
        }
        
        public string GenerateVariableHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"variable-item\">");
            sb.AppendLine("    <div class=\"variable-header\">");
            sb.AppendLine($"        <div class=\"cube {AccessModifier.ToLower()}\"></div>");
            sb.AppendLine($"        <span class=\"variable-name\">{DisplayName}</span>");
            sb.AppendLine("        <div class=\"toggle\" onclick=\"toggleVariable(this)\">+</div>");
            sb.AppendLine("    </div>");
            sb.AppendLine("    <div class=\"variable-details\">");
            sb.AppendLine($"        <div class=\"field\"><strong class=\"fieldName\">Variable Name: </strong> <span class=\"fieldValue\">{VariableName}</span></div>");
            sb.AppendLine($"        <div class=\"field\"><strong class=\"fieldName\">Access Modifier: </strong> <span class=\"fieldValue\">{AccessModifier}</span></div>");
            sb.AppendLine($"        <div class=\"field\"><strong class=\"fieldName\">Type: </strong> <span class=\"fieldValue\">{VariableType}</span></div>");
            sb.AppendLine("    </div>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }
    }
}