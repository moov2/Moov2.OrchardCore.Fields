﻿using Etch.OrchardCore.Fields.Colour.Fields;
using Etch.OrchardCore.Fields.Colour.ViewModels;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Etch.OrchardCore.Fields.Colour.Settings
{
    public class ColourFieldSettingsDriver : ContentPartFieldDefinitionDisplayDriver<ColourField>
    {
        #region Driver Methods

        #region Edit

        public override IDisplayResult Edit(ContentPartFieldDefinition model)
        {
            return Initialize<EditColourFieldSettingsViewModel>("ColourFieldSettings_Edit", viewModel =>
            {
                var settings = model.GetSettings<ColourFieldSettings>();

                viewModel.AllowCustom = settings.AllowCustom;
                viewModel.AllowTransparent = settings.AllowTransparent;
                viewModel.Colours = string.Join(",", settings.Colours);
                viewModel.Hint = settings.Hint;
            })
            .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition model, UpdatePartFieldEditorContext context)
        {
            var viewModel = new EditColourFieldSettingsViewModel();

            if (await context.Updater.TryUpdateModelAsync(viewModel, Prefix))
            {
                context.Builder.WithSettings(new ColourFieldSettings
                {
                    AllowCustom = viewModel.AllowCustom,
                    AllowTransparent = viewModel.AllowTransparent,
                    Colours = viewModel.Colours.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray(),
                    Hint = viewModel.Hint
                });
            }

            return Edit(model);
        }

        #endregion

        #endregion
    }
}