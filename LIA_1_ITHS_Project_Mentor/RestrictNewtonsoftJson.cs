///////////////////////////////////////////////////////////////////////////////////////////////////
/// This code has been copied from:                                                             ///
/// https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0         ///
///                                                                                             ///
/// This code will restrict the NewtonsoftJson to only be applied for the JSON Patch requests   ///
///////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace JsonPatchSample;

public static class RestrictNewtonsoftJson {
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() {
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}