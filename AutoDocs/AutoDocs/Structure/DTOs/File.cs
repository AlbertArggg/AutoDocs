namespace AutoDocs.Structure.DTOs
{
    public class File
    {
        public string FileName { get; private set; }
        public string FileDirectory { get; private set; }
        public string Icon { get; private set; }

        public File(string _name, string _dir, string _icon)
        {
            FileName = _name;
            FileDirectory = _dir;
            Icon = _icon;
        }
    }
}