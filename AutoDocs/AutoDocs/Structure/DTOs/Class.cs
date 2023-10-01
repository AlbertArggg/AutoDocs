using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoDocs.Structure.DTOs
{
    public class Class
    {
        public string ClassName { get; private set; }
        public string ClassDirectory { get; private set; }
        public string ClassIcon { get; private set; }
        
        public List<Variable> Variables {get; set;}
        public List<Function> Functions {get; set;}
        public List<Documentation> Documentations {get; set;}

        public Class(string _name, string _dir, string _icon, List<Variable> _vars, List<Function> _func, List<Documentation> _docs = null)
        {
            ClassName = _name;
            ClassDirectory = _dir;
            ClassIcon = _icon;
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
    }
}