using System.Collections.Generic;
using System.Text;
using AutoDocs.ExtensionMethods;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoDocs.Structure.DTOs
{
    public class Function
    {
        public string FunctionName { get; private set; }
        public string FunctionAccessModifier { get; private set; }
        public string FunctionDisplayName { get; private set; }
        public string FunctionContent { get; private set; }
        public string Node { get; private set; }
        
        public List<Parameter> Parameters {get; private set;}
        public List<Function> Functions {get; private set;}

        public List<Documentation> Documentations = new List<Documentation>();

        public Function(string _name, string _accMod, string _dir, string _cont, List<Parameter> _params, List<Function> _nestFunc)
        {
            FunctionName = _name;
            FunctionAccessModifier = _accMod;
            Parameters = _params;
            FunctionDisplayName = _name.SplitOnUpperCase();
            FunctionContent = _cont;
            Node = _dir;
            Functions = _nestFunc;
        }
        
        public string BuildFunctionHtml()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<div class=\"function-item\">");
            sb.AppendLine("<div class=\"function-header\">");
            sb.AppendLine($"<div class=\"cube {FunctionAccessModifier.ToLower()}\"></div>");
            sb.AppendLine($"<span class=\"function-name\">{FunctionDisplayName}</span>");
            sb.AppendLine("<div class=\"toggle\" onclick=\"toggleVariable(this)\">+</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div class=\"function-details\">");
            sb.AppendLine($"<div class=\"field\"><strong class=\"fieldName\">Function Name:</strong> <span class=\"fieldValue\">{FunctionName}</span></div>");
            sb.AppendLine($"<div class=\"field\"><strong class=\"fieldName\">Node:</strong> <span class=\"fieldValue\">{Node}</span></div>");

            if (Parameters.Count > 0)
            {
                sb.AppendLine("<div class=\"list-parameters\">");
                sb.AppendLine("<strong class=\"fieldName\">Parameters:</strong>");
                sb.AppendLine("<table>");
                sb.AppendLine("<thead>");
                sb.AppendLine("<tr>");
                sb.AppendLine("<th>Display Name</th>");
                sb.AppendLine("<th>Parameter Name</th>");
                sb.AppendLine("<th>Parameter Type</th>");
                sb.AppendLine("</tr>");
                sb.AppendLine("</thead>");
                sb.AppendLine("<tbody>");

                foreach (var param in Parameters)
                {
                    sb.AppendLine(param.GenerateParameterHTML());
                }

                sb.AppendLine("</tbody>");
                sb.AppendLine("</table>");
                sb.AppendLine("</div>");
            }

            sb.AppendLine("<div class=\"function-content\">");
            sb.AppendLine($"<pre><code class=\"cs\"><strong>{FunctionContent}</strong></code></pre>");
            sb.AppendLine("</div>");

            if (Functions.Count > 0)
            {
                sb.AppendLine("<div class=\"function-item\">");
                sb.AppendLine("<div class=\"variable-header\">");
                sb.AppendLine($"<div class=\"cube {FunctionAccessModifier.ToLower()}\"></div>");
                sb.AppendLine("<span class=\"variable-name\">Nested Functions</span>");
                sb.AppendLine("<div class=\"toggle\" onclick=\"toggleVariable(this)\">+</div>");
                sb.AppendLine("</div>");
                
                foreach (Function func in Functions)
                {
                    sb.AppendLine("<div class=\"variable-details\">");
                    sb.AppendLine(func.BuildFunctionHtml());
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");
            }

            sb.AppendLine("</div>");
            sb.AppendLine("</div>");

            return sb.ToString();
        }
    }
}