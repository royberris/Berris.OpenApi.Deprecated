using Microsoft.OpenApi.Models;

namespace Microsoft.AspNetCore.OpenApi;

/// <summary>
/// Transforms the operation to be deprecated if the endpoint metadata has the <see cref="DeprecatedEndpointMetadata"/>.
/// </summary>
public sealed class DeprecatedOperationTransformer : IOpenApiOperationTransformer
{
    public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context,
        CancellationToken cancellationToken)
    {
        var metadata = context.Description.ActionDescriptor.EndpointMetadata
            .OfType<DeprecatedEndpointMetadata>()
            .ToArray();

        if (metadata.Any())
        {
            operation.Deprecated = metadata
                .All(i => i.Deprecated);
        }
                
        return Task.CompletedTask;
    }
}