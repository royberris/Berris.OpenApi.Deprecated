namespace Microsoft.AspNetCore.OpenApi;

/// <summary>
/// Metadata for marking an endpoint as deprecated.
/// </summary>
/// <param name="Deprecated">Indicates whether the endpoint should be marked as deprecated.</param>
public record DeprecatedEndpointMetadata(bool Deprecated);