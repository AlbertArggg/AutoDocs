namespace AutoDocs.Structure.DTOs
{
    public class NameSpace
    {
        public string NameSpaceName  { get; private set; }
        public string NameSpaceDirectory { get; private set; }
        public string Icon  { get; private set; }

        public NameSpace(string _name, string _dir, string _icon)
        {
            NameSpaceName = _name;
            NameSpaceDirectory = _dir;
            Icon = _icon;
        }
    }
}