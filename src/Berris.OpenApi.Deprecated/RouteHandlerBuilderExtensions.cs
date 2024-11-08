using Microsoft.AspNetCore.OpenApi;

namespace Microsoft.AspNetCore.Builder;

public static class RouteHandlerBuilderExtensions
{
    /// <summary>
    /// Marks the endpoint as deprecated. Meaning it should not be used.
    /// </summary>
    public static RouteHandlerBuilder IsDeprecated(this RouteHandlerBuilder builder)
    {
        return builder.WithMetadata(new DeprecatedEndpointMetadata());
    }
}