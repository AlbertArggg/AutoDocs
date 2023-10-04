using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoDocs.Structure.Builder
{
    public class IconManager
    {
        private const string 
            _IconLocation = "Resources\\FileTypeIcons",
            _FileEnding = ".png",
            _Directory = "Directory",
            _Function = "Function",
            _Variable = "Variable";
        
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
            WebAssets = new List<string> { ".html", ".htm" ,".css", ".scss", ".less", ".sass" , ".js", ".jsx", ".ts", ".tsx" },
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
            MiscellaneousResourceFiles = new List<string> { ".resx", ".properties", ".plist" };
        
        private static readonly Dictionary<List<string>, string> fileTypeToIconMapping = new Dictionary<List<string>, string>
        {
            { ConfigurationAndScriptFiles, _ConfigFile },
            { WebAssets, _WebFile },
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
            { MiscellaneousResourceFiles, _MiscFile }
        };

        public static string GetDirectoryIcon() { return $"{_IconLocation}\\{_Directory}{_FileEnding}"; }
        public static string GetFunctionIcon() { return $"{_IconLocation}\\{_Function}{_FileEnding}"; }
        public static string GetVariableIcon() { return $"{_IconLocation}\\{_Variable}{_FileEnding}"; }

        public static string GetFileIcon(string file)
        {
            var fileExtension = System.IO.Path.GetExtension(file) ?? throw new ArgumentNullException(file);
            if (fileExtension == null) throw new ArgumentNullException(nameof(fileExtension));

            if (fileExtension == ".sln") { return $"{_IconLocation}\\{_SlnFile}{_FileEnding}"; }
            if (fileExtension == ".csproj") { return $"{_IconLocation}\\{_CsProj}{_FileEnding}"; }
            if (fileExtension == ".xcodeproj") { return $"{_IconLocation}\\{_XCodeFile}{_FileEnding}"; }
            if (fileExtension == ".vcxproj") { return $"{_IconLocation}\\{_VcxFile}{_FileEnding}"; }
            if (fileExtension == ".bin") { return $"{_IconLocation}\\{_BinFile}{_FileEnding}"; }
            if (fileExtension == ".obj") { return $"{_IconLocation}\\{_ObjFile}{_FileEnding}"; }
            if (fileExtension == ".dll") { return $"{_IconLocation}\\{_DllFile}{_FileEnding}"; }
            if (fileExtension == ".exe") { return $"{_IconLocation}\\{_ExeFile}{_FileEnding}"; }

            foreach (var mapping in fileTypeToIconMapping.Where(mapping => mapping.Key.Contains(fileExtension)))
            {
                return $"{_IconLocation}\\{mapping.Value}{_FileEnding}";
            }

            return $"{_IconLocation}\\Default{_FileEnding}";
        }

        public static string GetCsFileIcon(string filePath)
        {
            var tree = CSharpSyntaxTree.ParseText(File.ReadAllText(filePath));
            var root = tree.GetCompilationUnitRoot();
            
            foreach (var typeDeclaration in root.DescendantNodes().OfType<TypeDeclarationSyntax>())
            {
                switch (typeDeclaration.Kind())
                {
                    case SyntaxKind.ClassDeclaration:
                        var classDeclaration = typeDeclaration as ClassDeclarationSyntax;
                        if (classDeclaration != null && classDeclaration.Modifiers.Any(SyntaxKind.StaticKeyword))
                            return _CsStaticClass;
                        if (classDeclaration != null && classDeclaration.Modifiers.Any(SyntaxKind.AbstractKeyword))
                            return _CsAbstractClass;
                        return _CsClass;

                    case SyntaxKind.InterfaceDeclaration: return _CsInterface;
                    case SyntaxKind.EnumDeclaration: return _CsEnum;
                    case SyntaxKind.StructDeclaration: return _CsStruct;
                    case SyntaxKind.DelegateDeclaration: return _CsDelegate;
                    default: return _CsClass;
                }
            }
            return null;
        }
    }
}