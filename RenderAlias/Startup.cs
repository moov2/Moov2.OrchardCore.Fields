using Etch.OrchardCore.Fields.RenderAlias.Drivers;
using Etch.OrchardCore.Fields.RenderAlias.Fields;
using Etch.OrchardCore.Fields.RenderAlias.ViewModels;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Modules;

namespace Etch.OrchardCore.Fields.RenderAlias
{
    [Feature("Etch.OrchardCore.Fields.RenderAlias")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentField<RenderAliasField>()
                .UseDisplayDriver<RenderAliasFieldDisplayDriver>();

            services.Configure<TemplateOptions>(o =>
            {
                o.MemberAccessStrategy.Register<RenderAliasField>();
                o.MemberAccessStrategy.Register<RenderAliasFieldViewModel>();
            });
        }
    }
}
