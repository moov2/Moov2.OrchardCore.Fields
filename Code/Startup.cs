using Etch.OrchardCore.Fields.Code.Drivers;
using Etch.OrchardCore.Fields.Code.Fields;
using Etch.OrchardCore.Fields.Code.Settings;
using Etch.OrchardCore.Fields.Code.ViewModels;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.Code
{
    [Feature("Etch.OrchardCore.Fields.Code")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentField<CodeField>()
                .UseDisplayDriver<CodeFieldDisplayDriver>();

            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, CodeFieldSettingsDriver>();

            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<CodeField>();
                o.MemberAccessStrategy.Register<DisplayCodeFieldViewModel>();
            });
        }
    }
}
