namespace AutoDocs.Structure.DTOs
{
    public class Parameter
    {
        public string ParameterName;
        public string ParameterType;

        public Parameter(string _name, string _type)
        {
            ParameterName = _name;
            ParameterType = _type;
        }
    }
}