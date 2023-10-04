using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AutoDocs.Structure.DTOs;
using File = System.IO.File;

namespace AutoDocs.Structure.Builder
{
    public static class Builder
    {
        public static DTOs.Directory BuildCodeStructure(string _dir)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_dir);
            
            var directories = directoryInfo.GetDirectories()
                .Select(d => BuildCodeStructure(d.FullName))
                .ToList();
            
            List<Class> classes = directoryInfo.GetFiles("*.cs")
                .SelectMany(f => BuildClassesStructure(f.FullName))
                .ToList();
            
            var files = directoryInfo.GetFiles()
                .Where(f => f.Extension != ".cs")
                .Select(f => BuildFileStructure(f.FullName))
                .ToList();
            
            string icon = IconManager.GetDirectoryIcon();
            
            return new DTOs.Directory(directoryInfo.Name, directoryInfo.FullName, icon, directories, classes, files);
        }
        
        private static List<Class> BuildClassesStructure(string filePath)
        {
            try
            {
                var tree = CSharpSyntaxTree.ParseText(File.ReadAllText(filePath));
                var root = tree.GetRoot();

                var classNodes = root.DescendantNodes().OfType<ClassDeclarationSyntax>().ToList();

                if (!classNodes.Any()) return new List<Class>();

                return classNodes.Select(classNode => 
                {
                    var className = classNode.Identifier.Text;
                    var classDirectory = Path.GetDirectoryName(filePath);
                    var classIcon = IconManager.GetCsFileIcon(filePath);
                    var funcIcon = IconManager.GetFunctionIcon();
                    var varIcon = IconManager.GetVariableIcon();

                    var variables = classNode.DescendantNodes()
                        .OfType<PropertyDeclarationSyntax>()
                        .Select(p => new Variable(p.Type.ToString(), p.Identifier.ToString(), p.Modifiers.FirstOrDefault().Text ?? "default"))
                        .ToList();

                    var functions = classNode.DescendantNodes()
                        .OfType<MethodDeclarationSyntax>()
                        .Select(BuildFunctionStructure)
                        .ToList();

                    return new Class(className, classDirectory, classIcon, funcIcon, varIcon, variables, functions);
                }).ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine($@"Error processing file {filePath}: {ex.Message}");
                return new List<Class>();
            }
        }

        
        private static DTOs.File BuildFileStructure(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            string iconName = IconManager.GetFileIcon(filePath);
            return new DTOs.File(fileInfo.Name, fileInfo.DirectoryName, iconName);
        }
        
        private static Function BuildFunctionStructure(MethodDeclarationSyntax methodNode)
        {
            var functionName = methodNode.Identifier.Text;
            var AccessModifier = methodNode.Modifiers.FirstOrDefault();

            var parameters = methodNode.ParameterList.Parameters
                .Select(p => new Parameter(p.Identifier.ToString(), p.Type?.ToString()))
                .ToList();
            
            var nestedFunctionsList = methodNode.DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Select(BuildFunctionStructure)
                .ToList();
            
            var functionContent = methodNode.Body?.ToFullString() ?? "";

            return new Function(functionName, AccessModifier.ToString(), methodNode.ToString(), functionContent, parameters, nestedFunctionsList);
        }

        private static string GetXmlElementValue(XDocument doc, string elementName)
        {
            return doc.Descendants(elementName).FirstOrDefault()?.Value.Trim();
        }
    }
}