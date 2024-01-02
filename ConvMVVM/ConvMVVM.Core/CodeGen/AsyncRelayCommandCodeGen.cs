﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Collections.Immutable;
using System.Diagnostics;
using ConvMVVM.Core.CodeGen.GenInfo;


namespace ConvMVVM.Core.CodeGen
{
    [Generator]
    internal class AsyncRelayCommandCodeGen : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {

//#if DEBUG
//            if (!Debugger.IsAttached)
//            {
//                Debugger.Launch();
//            }
//#endif

            var classDeclarations = context.SyntaxProvider
                                           .CreateSyntaxProvider(predicate: static (s, _) => AsyncRelayCommandCodeGen.IsSyntaxForCodeGen(s),
                                                                 transform: static (ctx, _) => AsyncRelayCommandCodeGen.GetTargetForCodeGen(ctx))
                                           .Where(x => x != null);


            IncrementalValueProvider<(Compilation, ImmutableArray<ClassDeclarationSyntax>)> compilationAndClass = context.CompilationProvider.Combine(classDeclarations.Collect());
            context.RegisterSourceOutput(compilationAndClass, static (spc, source) => AsyncRelayCommandCodeGen.RelayCommandCodeExecute(source.Item1, source.Item2, spc));
        }



        #region Filter
        internal static bool IsSyntaxForCodeGen(SyntaxNode node)
        {
            if (node is not ClassDeclarationSyntax) return false;
            var classSyntax = (ClassDeclarationSyntax)node;
            if (classSyntax.Members.Count == 0) return false;
            if (classSyntax.Members.Where((syntax) => syntax.AttributeLists.Count > 0).Count() == 0) return false;
            return true;
        }

        internal static ClassDeclarationSyntax GetTargetForCodeGen(GeneratorSyntaxContext context)
        {
            var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;


            foreach (var memeberSyntax in classDeclarationSyntax.Members)
            {
                foreach (AttributeListSyntax attributeListSyntax in memeberSyntax.AttributeLists)
                {
                    foreach (AttributeSyntax attributeSyntax in attributeListSyntax.Attributes)
                    {
                        if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                        {
                            continue;
                        }
                        INamedTypeSymbol attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                        string fullName = attributeContainingTypeSymbol.ToDisplayString();
                        if (fullName == "ConvMVVM.Core.Attributes.AsyncRelayCommandAttribute")
                        {
                            return classDeclarationSyntax;
                        }
                    }
                }
            }


            return null;
        }
        #endregion

        #region Generator
        internal static string GetNamespace(Compilation compilation, MemberDeclarationSyntax cls)
        {
            var model = compilation.GetSemanticModel(cls.SyntaxTree);

            foreach (NamespaceDeclarationSyntax ns in cls.Ancestors().OfType<NamespaceDeclarationSyntax>())
            {
                return ns.Name.ToString();
            }

            return "";
        }

        internal static List<AutoMethodInfo> GetMethodList(Compilation compilation, MemberDeclarationSyntax cls)
        {
            List<AutoMethodInfo> methodList = new List<AutoMethodInfo>();
            var model = compilation.GetSemanticModel(cls.SyntaxTree);
            foreach (MethodDeclarationSyntax method in cls.DescendantNodes().OfType<MethodDeclarationSyntax>())
            {

                var returnType = method.ReturnType.ToString();
                if (returnType != "Task") continue;

                var asyncCount = method.Modifiers.Where(syntax => syntax.ToString() == "async").Count();
                switch (method.ParameterList.Parameters.Count)
                {
                    case 0:
                        methodList.Add(new AutoMethodInfo()
                        {
                            MethodName = method.Identifier.ToString(),
                            ArgumentType = "",
                            AsyncCount = asyncCount,
                        });
                        break;
                    case 1:
                        methodList.Add(new AutoMethodInfo()
                        {
                            MethodName = method.Identifier.ToString(),
                            ArgumentType = method.ParameterList.Parameters[0].Type.ToString(),
                            AsyncCount = asyncCount,
                        });
                        break;
                }
            }

            return methodList;
        }

        internal static void RelayCommandCodeExecute(Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes, SourceProductionContext context)
        {
            if (classes.IsDefaultOrEmpty)
            {
                return;
            }

            IEnumerable<ClassDeclarationSyntax> distinctClasses = classes.Distinct();
            foreach (var cls in distinctClasses)
            {
                string clsNamespace = GetNamespace(compilation, cls);
                if (cls.Modifiers.Count == 0) continue;
                if (cls.Modifiers.Where((token) => token.ToString().Contains("partial") == true).Count() == 0)
                {
                    var description = new DiagnosticDescriptor("ConvMVVM0001",
                                                               "Wrong class modifier",
                                                               $"{clsNamespace}.{cls.Identifier.ValueText} class modifier must be partial",
                                                               "Problem",
                                                               DiagnosticSeverity.Error,
                                                               true);
                    context.ReportDiagnostic(Diagnostic.Create(description, Location.None));
                }

                if (cls.BaseList.Types.Count == 0)
                {
                    var description = new DiagnosticDescriptor("ConvMVVM0002",
                                           "None inheritance",
                                           $"{clsNamespace}.{cls.Identifier.ValueText} class have to inhert NotifyObject",
                                           "Problem",
                                           DiagnosticSeverity.Error,
                                           true);
                    context.ReportDiagnostic(Diagnostic.Create(description, Location.None));
                }

                List<AutoMethodInfo> methodList = GetMethodList(compilation, cls);
                if (methodList.Count == 0) continue;

                var source = """
                using ConvMVVM.Core.Component;
                using System.Windows.Input;

                namespace {clsNamespace}{
                    partial class {clsName}{
                
                {methodCollection}
                        
                    }
                }
                """;

                var propertyCodeGroup = "";
                foreach (var method in methodList)
                {

                    if(method.AsyncCount == 0)
                    {
                        var description = new DiagnosticDescriptor("ConvMVVM0004",
                                                                   "None async modifier",
                                                                   $"{clsNamespace}.{cls.Identifier.ValueText}.{method.MethodName} doesn't have async modifier",
                                                                   "Problem",
                                                                   DiagnosticSeverity.Error,
                                                                   true);
                        context.ReportDiagnostic(Diagnostic.Create(description, Location.None));

                        continue; 
                    }



                    if (method.ArgumentType == "")
                    {
                        string propertyCode = """

                                public ICommand _{methodName}Command = null;
                                public ICommand {methodName}Command{
                                    get{
                                        _{methodName}Command = new AsyncRelayCommand(()=> this.{methodName}());
                                        return _{methodName}Command;
                                    }
                                }

                        """;

                        propertyCode = propertyCode.Replace("{methodName}", method.MethodName);
                        propertyCodeGroup += propertyCode;
                    }
                    else
                    {
                        string propertyCode = """

                                public ICommand _{methodName}Command = null;
                                public ICommand {methodName}Command{
                                    get{
                                        _{methodName}Command = new AsyncRelayCommand<{arg}>((arg)=> this.{methodName}(arg));
                                        return _{methodName}Command;
                                    }
                                }

                        """;

                        propertyCode = propertyCode.Replace("{methodName}", method.MethodName);
                        propertyCode = propertyCode.Replace("{arg}", method.ArgumentType);
                        propertyCodeGroup += propertyCode;
                    }

                }

                source = source.Replace("{methodCollection}", propertyCodeGroup);
                source = source.Replace("{clsNamespace}", clsNamespace);
                source = source.Replace("{clsName}", cls.Identifier.ValueText);
                source = source.Replace("{methodCollection}", propertyCodeGroup);

                context.AddSource($"{clsNamespace}.{cls.Identifier.ValueText}.g.cs", SourceText.From(source, Encoding.UTF8));

            }
        }
        #endregion

    }

}
