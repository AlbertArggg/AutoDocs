namespace AutoDocs.Structure.DTOs
{
    public class Variable
    {
        public string VariableName;
        public string VariableType;
        
        public Variable(string _name, string _type)
        {
            VariableName = _name;
            VariableType = _type;
        }
    }
}