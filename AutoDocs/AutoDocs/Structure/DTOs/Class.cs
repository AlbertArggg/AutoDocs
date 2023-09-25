using System.Collections.Generic;

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

        public Class(string _name, string _dir, string _icon, List<Variable> _vars, List<Function> _func, List<Documentation> _docs)
        {
            ClassName = _name;
            ClassDirectory = _dir;
            ClassIcon = _icon;
            Variables = _vars;
            Functions = _func;
            Documentations = _docs;
        }
    }
}