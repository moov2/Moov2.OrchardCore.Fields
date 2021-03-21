using Etch.OrchardCore.Fields.Colour.Drivers;
using Etch.OrchardCore.Fields.Colour.Fields;
using Etch.OrchardCore.Fields.Colour.Settings;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Settings;

namespace Etch.OrchardCore.Fields.Colour
{
    [Feature("Etch.OrchardCore.Fields.Colour")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentField<ColourField>()
                .UseDisplayDriver<ColourFieldDisplayDriver>();

            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, ColourFieldSettingsDriver>();

            services.AddScoped<INavigationProvider, AdminMenu>();
            services.AddScoped<IDisplayDriver<ISite>, ColourSettingsDisplayDriver>();

            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<ColourField>();
            });
        }
    }
}
