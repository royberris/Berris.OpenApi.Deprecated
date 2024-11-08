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
        operation.Deprecated = context.Description.ActionDescriptor.EndpointMetadata
            .OfType<DeprecatedEndpointMetadata>()
            .FirstOrDefault() is not null;

        return Task.CompletedTask;
    }
}