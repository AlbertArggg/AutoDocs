﻿using System;
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
            
            string icon = "path_to_icon_based_on_some_logic";
            
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
                    string classIcon = "path_to_icon_based_on_some_logic";

                    var variables = classNode.DescendantNodes()
                        .OfType<PropertyDeclarationSyntax>()
                        .Select(p => new Variable(p.Type.ToString(), p.Identifier.ToString()))
                        .ToList();

                    var functions = classNode.DescendantNodes()
                        .OfType<MethodDeclarationSyntax>()
                        .Select(BuildFunctionStructure)
                        .ToList();

                    return new Class(className, classDirectory, classIcon, variables, functions);
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
            string iconName = null;
            return new DTOs.File(fileInfo.Name, fileInfo.DirectoryName, iconName);
        }
        
        private static Function BuildFunctionStructure(MethodDeclarationSyntax methodNode)
        {
            var functionName = methodNode.Identifier.Text;
            string functionIcon = "default_function_icon";

            var parameters = methodNode.ParameterList.Parameters
                .Select(p => new Parameter(p.Identifier.ToString(), p.Type?.ToString()))
                .ToList();
            
            var nestedFunctions = methodNode.DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Select(BuildFunctionStructure)
                .ToList();

            return new Function(functionName, methodNode.ToString(), functionIcon, parameters);
        }

        private static string GetXmlElementValue(XDocument doc, string elementName)
        {
            return doc.Descendants(elementName).FirstOrDefault()?.Value.Trim();
        }
    }
}