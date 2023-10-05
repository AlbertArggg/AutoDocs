using System;
using System.Collections.Generic;
using System.Text;
using AutoDocs.ExtensionMethods;
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

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
        private static AdhocWorkspace _workSpace;

        public Function(string _name, string _accMod, string _dir, string _cont, List<Parameter> _params, List<Function> _nestFunc)
        {
            FunctionName = _name;
            FunctionAccessModifier = _accMod;
            Parameters = _params;
            FunctionDisplayName = _name.SplitOnUpperCase();
            FunctionContent = _cont;
            Node = Deindent(_dir);
            Console.WriteLine(Node);
            Functions = _nestFunc;
        }
        
        public static string Deindent(string input)
        {
            // 1. Create a syntax tree from your input string
            AdhocWorkspace workspace = new AdhocWorkspace();
            workspace.AddSolution(SolutionInfo.Create(SolutionId.CreateNewId("formatter"), VersionStamp.Default));
            
            // 2. Setup a workspace and project
            ProjectId projectId = ProjectId.CreateNewId();
            Solution solution = workspace.CurrentSolution
                .AddProject(projectId, "AdhocProject", "AdhocProject", LanguageNames.CSharp)
                .WithProjectCompilationOptions(projectId, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddMetadataReference(projectId, MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddMetadataReference(projectId, MetadataReference.CreateFromFile(typeof(Console).Assembly.Location));
    
            // 3. Create a document from the syntax tree and add it to the project
            DocumentId documentId = DocumentId.CreateNewId(projectId);
            solution = solution.AddDocument(documentId, "AdhocDocument.cs", SourceText.From(input));
            Document document = solution.GetDocument(documentId);
    
            // 4. Use the `Formatter` to format the document
            SyntaxNode formattedRoot = Formatter.Format(document.GetSyntaxRootAsync().Result, workspace);
    
            // 5. Extract the formatted text
            string formattedText = formattedRoot.ToFullString();
    
            return formattedText;
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
            sb.AppendLine($"<pre><code class=\"cs\"><strong>");
            sb.AppendLine($"{Node}");
            sb.AppendLine("</strong></code></pre>");
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