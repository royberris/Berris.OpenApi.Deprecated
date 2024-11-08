using Microsoft.AspNetCore.OpenApi;

namespace Microsoft.Extensions.DependencyInjection;

public static class OpenApiOptionsExtensions
{
    public static void AddDeprecatedOperationTransformer(this OpenApiOptions options)
    {
        options.AddOperationTransformer(new DeprecatedOperationTransformer());
    }
}