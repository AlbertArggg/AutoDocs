namespace AutoDocs.Structure.DTOs
{
    public class Variable
    {
        public string VariableName;
        public string VariableType;
        public string AccessModifier;
        
        public Variable(string _name, string _type, string _accMod)
        {
            VariableName = _name;
            VariableType = _type;
            AccessModifier = _accMod;
        }
    }
}