using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace EntityId.Generator;

/// <summary>
/// Generates Entity IDs.
/// </summary>
/// <remarks>
/// Code inspired by similar library https://github.com/andrewlock/StronglyTypedId
/// </remarks>
[Generator]
public class EntityIdGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider.ForAttributeWithMetadataName(
            AttributeName,
            predicate: ShouldHandle,
            transform: GetIdTypeInfo
        ).Collect();

        context.RegisterSourceOutput(provider, Execute);
    }

    private const string AttributeName = $"EntityId.{nameof(EntityAttribute)}";

    private static bool ShouldHandle(SyntaxNode node, CancellationToken _)
        => node is ClassDeclarationSyntax;

    private static TypeInfo GetIdTypeInfo(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        var classDeclaration = (ClassDeclarationSyntax)context.TargetNode;
        var className = classDeclaration.Identifier.ToString();
        return new TypeInfo(className, GetClassFullPath(context, classDeclaration));
    }

    private static string GetClassFullPath(
        GeneratorAttributeSyntaxContext context, ClassDeclarationSyntax classDeclaration) 
        => context.SemanticModel.GetDeclaredSymbol(classDeclaration)?.ToString() ?? "";

    private void Execute(SourceProductionContext context, ImmutableArray<TypeInfo> entities)
    {
        var sb = new StringBuilder();
        foreach (var entity in entities)
        {
            AppendIdToFile(sb, entity);
        }
        context.AddSource($"EntityIdUsings.g.cs", sb.ToString());
    }

    private void AppendIdToFile(StringBuilder codeBuilder, TypeInfo entity)
    {
        var aliasName = $"{entity.ClassName}Id";
        var fullTypeName = $"EntityId.Id<{entity.ClassFullPath}>";
        codeBuilder.AppendLine($"global using {aliasName} = {fullTypeName};");
    }

    private record TypeInfo(string ClassName, string ClassFullPath);
}