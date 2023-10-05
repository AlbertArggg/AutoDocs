using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoDocs.ExtensionMethods;
using AutoDocs.Structure.Builder;

namespace AutoDocs.Structure.DTOs
{
    public class Class
    {
        public string ClassName { get; private set; }
        public string ClassDirectory { get; private set; }
        public string ClassIcon { get; private set; }
        public string FunctionIcon { get; private set; }
        public string VariableIcon { get; private set; }
        public string ClassDisplayName { get; private set; }
        public List<Variable> Variables {get; set;}
        public List<Function> Functions {get; set;}
        public List<Documentation> Documentations {get; set;}

        public Class(string _name, string _dir, string _icon, string _funcIcon, string _varIcon ,List<Variable> _vars, List<Function> _func, List<Documentation> _docs = null)
        {
            ClassName = _name;
            ClassDisplayName = _name.SplitOnUpperCase();
            ClassDirectory = _dir;
            ClassIcon = _icon;
            FunctionIcon = _funcIcon;
            VariableIcon = _varIcon;
            Variables = _vars;
            Functions = _func;
            Documentations = _docs;
        }
        
        public override string ToString()
        {
            using (StringWriter writer = new StringWriter())
            {
                writer.WriteLine($"Class Name: {ClassName}");
                writer.WriteLine($"Directory: {ClassDirectory}");
                writer.WriteLine($"Icon: {ClassIcon}");
                
                if (Variables != null && Variables.Any())
                {
                    writer.WriteLine("Variables:");
                    foreach (var variable in Variables)
                    {
                        writer.WriteLine($"\tName: {variable.VariableName}, Type: {variable.VariableType}");
                        // If Variable has a ToString() method, you can call it here for more details.
                    }
                }
                
                if (Functions != null && Functions.Any())
                {
                    writer.WriteLine("Functions:");
                    foreach (var function in Functions)
                    {
                        writer.WriteLine($"\tFunction Name: {function.FunctionName}");
                        // If Function has a ToString() method, you can call it here for more details.
                    }
                }
                
                if (Documentations != null && Documentations.Any())
                {
                    writer.WriteLine("Documentations:");
                    foreach (var doc in Documentations)
                    {
                        writer.WriteLine($"\tTitle: {doc.Title}");
                        writer.WriteLine($"\tDetails: {doc.Doc}");
                    }
                }

                return writer.ToString();
            }
        }

        public void BuildClassHtmlFile()
        {
            var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OutputHTML");
            if (!System.IO.Directory.Exists(outputPath))
            {
                System.IO.Directory.CreateDirectory(outputPath);
            }
            
            var filePath = Path.Combine(outputPath, $"{ClassName}.html");
            System.IO.File.WriteAllText(filePath, HTMLBuilder.GenerateClassHTML(this));
        }

        public string GenerateClassHtml()
        {
            StringBuilder sb = new StringBuilder();
            
            // ClassIcon + Display Name
            sb.AppendLine("<div class=\"function-list\">");
            sb.AppendLine($"<div class=\"subsection-title\"> <img src=\"{FunctionIcon}\" width=\"30px\", height=\"30px\"> {ClassDisplayName} </div>");
            
            // Class name, Directory
            sb.AppendLine($"<div class=\"field\"><strong class=\"fieldName\">Class Name: </strong> <span class=\"fieldValue\">{ClassName}</span></div>");
            sb.AppendLine($"<div class=\"field\"><strong class=\"fieldName\">Directory: </strong> <span class=\"fieldValue\">{ClassDirectory}</span></div>");

            // Need Sub classes, access mod, class type, Documentations
            
            // Variables
            if (Variables.Count > 0)
            {
                sb.AppendLine("<div class=\"variable-list\">");
                sb.AppendLine($"<div class=\"subsection-title\"> <img src=\"{VariableIcon}\" width=\"30px\", height=\"30px\"> Variables </div>");
                foreach (Variable var in Variables)
                {
                    sb.AppendLine(var.GenerateVariableHtml());
                }
                sb.AppendLine("</div>");
            }
            
            // Functions
            if (Functions.Count > 0)
            {
                sb.AppendLine("<div class=\"function-list\">");
                sb.AppendLine($"<div class=\"subsection-title\"> <img src=\"{FunctionIcon}\" width=\"30px\", height=\"30px\"> Functions </div>");
                foreach (Function var in Functions)
                {
                    sb.AppendLine(var.BuildFunctionHtml());
                }
                sb.AppendLine("</div>");   
            }
            sb.AppendLine("</div>"); 
            return sb.ToString();
        }
    }
}