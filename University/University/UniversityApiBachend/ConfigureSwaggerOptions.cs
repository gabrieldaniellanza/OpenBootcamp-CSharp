using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace UniversityApiBackend
{

    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {

        private readonly IApiVersionDescriptionProvider _provider; 
        
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this._provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {

            OpenApiInfo openApiInfo = new OpenApiInfo()
            {
                Title = "My .Net api restful",
                Description = "This is my firt API versioning control",
                Version = description.ApiVersion.ToString(),
                Contact = new OpenApiContact()
                {
                    Email = "gdl@contacto.com",
                    Name = "Gabriel"
                }
            };

            if (description.IsDeprecated)
            {
                openApiInfo.Description += "This API verision has been deprecated";
            }

            return openApiInfo;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            
            foreach(var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }
    }
}
