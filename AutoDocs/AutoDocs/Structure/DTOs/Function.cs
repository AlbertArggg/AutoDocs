using System.Collections.Generic;

namespace AutoDocs.Structure.DTOs
{
    public class Function
    {
        public string FunctionName { get; private set; }
        public string ClassIcon { get; private set; }
        
        public List<Parameter> Parameters {get; set;}
        public List<Function> Functions {get; set;}
        public List<Documentation> Documentations {get; set;}

        public Function(string _name, string _dir, string _icon, List<Parameter> _params, List<Documentation> _docs = null)
        {
            FunctionName = _name;
            ClassIcon = _icon;
            Parameters = _params;
        }
    }
}