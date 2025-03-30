using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace EntityId.Generator
{
    [Generator]
    public class EntityIdGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var provider = context.SyntaxProvider.ForAttributeWithMetadataName(
                $"EntityId.{nameof(EntityAttribute)}",
                predicate: ShouldHandle,
                transform: GetIdTypeInfo
            ).Collect();

            context.RegisterSourceOutput(provider, Execute);
        }

        private static TypeInfo GetIdTypeInfo(GeneratorAttributeSyntaxContext context, CancellationToken _)
        {
            var classDeclaration = (ClassDeclarationSyntax)context.TargetNode;
            var typeSymbol = context.SemanticModel.GetDeclaredSymbol(classDeclaration);
            var className = classDeclaration.Identifier.ToString();
            var classFullPath = typeSymbol!.ToString() ?? "";
            return new TypeInfo(className, classFullPath);
        }

        private static bool ShouldHandle(SyntaxNode node, CancellationToken _) => true;

        private void Execute(SourceProductionContext context, ImmutableArray<TypeInfo> entities)
        {
            var sb = new StringBuilder();
            foreach (var entity in entities)
            {
                AppendId(sb, entity);
            }
            context.AddSource($"EntityIdUsings.g.cs", sb.ToString());
        }

        private void AppendId(StringBuilder codeBuilder, TypeInfo entity)
        {
            var aliasName = $"{entity.ClassName}Id";
            var fullTypeName = $"EntityId.Id<{entity.ClassFullPath}>";
            codeBuilder.AppendLine($"global using {aliasName} = {fullTypeName};");
        }

        private record TypeInfo(string ClassName, string ClassFullPath);
    }
}