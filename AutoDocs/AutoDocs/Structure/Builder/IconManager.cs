using System.Collections.Generic;
using System.Reflection.Metadata;
#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace AutoDocs.Structure.Builder
{
    public class IconManager
    {
        private static readonly Dictionary<List<string>, string> fileTypeToIconMapping = new Dictionary<List<string>, string>
        {
            { ConfigurationAndScriptFiles, _ConfigFile },
            { WebAssetsHTML, _WebFile },
            { WebAssetsCSS, _WebFile },
            { WebAssetsJS, _WebFile },
            { DatabaseFiles, _DataBaseFile },
            { ImageFiles, _ImageFile },
            { AudioFiles, _AudioFile },
            { VideoFiles, _VideoFile },
            { DocumentFiles, _DocFile },
            { FontFiles, _FontFile },
            { ArchiveAndCompressedFiles, _ZipFile },
            { BinaryAndObjectFiles, _BinFile },
            { LogAndReportFiles, _LogFile },
            { ThreeDModelsAndGraphicsFiles, _3DFileObject },
            { AnimationAndTimeline, _AnimationFile },
            { ShaderFiles, _ShaderFile },
            { LocalizationAndTranslationFiles, _MiscFile },
            { ProjectAndWorkspaceFiles, _MiscFile },
            { MiscellaneousResourceFiles, _MiscFile }
        };
        
        private const string 
            _IconLocation = "Resources\\FileTypeIcons",
            _FileEnding = ".png",
            _Directory = "Directory";
        
        private const string 
            _3DFileObject = "3DFile", 
            _AnimationFile = "AnimationFile", 
            _AudioFile = "AudioFile",
            _BinFile = "BinFile",
            _ConfigFile = "ConfigFile",
            _CsProj = "CsProj",
            _DataBaseFile = "DataBaseFile",
            _DllFile = "DllFile",
            _DocFile = "DocFile",
            _ExeFile = "ExeFile",
            _FontFile = "FontFile",
            _ImageFile = "ImageFile",
            _LogFile = "LogFile",
            _MiscFile = "MiscFile",
            _ObjFile = "ObjFile",
            _ShaderFile = "ShaderFile",
            _SlnFile = "SlnFile",
            _VcxFile = "Vcx",
            _VideoFile = "VideoFile",
            _WebFile = "WebFile",
            _XCodeFile = "XCodeProj",
            _ZipFile = "ZipFile";
        
        private const string 
            _CsClass = "CS_Class",
            _CsAbstractClass = "CS_AbstractClass",
            _CsDelegate = "CS_Delegate",
            _CsEnum = "CS_Enum",
            _CsInterface = "CS_Interface",
            _CsMonoClass = "CS_MonoClass",
            _CsStaticClass = "CS_StaticClass",
            _CsStruct = "CS_Struct";
        
        private static readonly List<string> 
            ConfigurationAndScriptFiles = new List<string> { ".xml", ".json", ".yml", ".ini", ".sh", ".bat" },
            WebAssetsHTML = new List<string> { ".html", ".htm" },
            WebAssetsCSS = new List<string> { ".css", ".scss", ".less", ".sass" },
            WebAssetsJS = new List<string> { ".js", ".jsx", ".ts", ".tsx" },
            DatabaseFiles = new List<string> { ".sql", ".db", ".mdf", ".ldf", ".sqlite" },
            ImageFiles = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".svg", ".webp", ".tiff", ".ico" },
            AudioFiles = new List<string> { ".mp3", ".wav", ".ogg", ".m4a", ".flac", ".aac" },
            VideoFiles = new List<string> { ".mp4", ".avi", ".mkv", ".flv", ".mov", ".webm" },
            DocumentFiles = new List<string> { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".md" },
            FontFiles = new List<string> { ".ttf", ".otf", ".woff", ".woff2", ".eot" },
            ArchiveAndCompressedFiles = new List<string> { ".zip", ".rar", ".tar", ".gz", ".7z", ".bz2" },
            BinaryAndObjectFiles = new List<string> { ".bin", ".obj", ".o", ".a", ".dll", ".so", ".exe" },
            LogAndReportFiles = new List<string> { ".log", ".report" },
            ThreeDModelsAndGraphicsFiles = new List<string> { ".obj", ".fbx", ".dae", ".3ds" },
            AnimationAndTimeline = new List<string> { ".anim", ".timeline" },
            ShaderFiles = new List<string> { ".shader", ".vert", ".frag" },
            LocalizationAndTranslationFiles = new List<string> { ".po", ".pot", ".mo", ".strings" },
            ProjectAndWorkspaceFiles = new List<string> { ".sln", ".csproj", ".xcodeproj", ".vcxproj" },
            MiscellaneousResourceFiles = new List<string> { ".resx", ".properties", ".plist" };

        public static string GetFileIcon(string file)
        {
            string fileExtension = System.IO.Path.GetExtension(file);
            foreach (var mapping in fileTypeToIconMapping)
            {
                if (mapping.Key.Contains(fileExtension)) { return $"{_IconLocation}\\{mapping.Value}{_FileEnding}"; }
            }
            return $"{_IconLocation}\\DefaultIcon{_FileEnding}";
        }
    }
}