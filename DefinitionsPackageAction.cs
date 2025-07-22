using System;
using System.Text.Json;
using System.Reflection;
using BlockFarmEditor.RCL.Library.Services;
using BlockFarmEditor.RCL.Models;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Packaging;
using Microsoft.Extensions.Logging;

namespace BlockFarmEditor.Bootstrap.Package;

internal class DefinitionsPackageAction(
    IPackagingService packagingService
        , IMediaService mediaService
        , MediaFileManager mediaFileManager
        , MediaUrlGeneratorCollection mediaUrlGenerators
        , IShortStringHelper shortStringHelper
        , IContentTypeBaseServiceProvider contentTypeBaseServiceProvider
        , IMigrationContext context
        , IOptions<PackageMigrationSettings> packageMigrationsSettings
        , IBlockFarmEditorDefinitionService blockFarmEditorDefinitionService
        , IUserService userService
        , ILogger<DefinitionsPackageAction> logger) : AsyncPackageMigrationBase(packagingService, mediaService, mediaFileManager, mediaUrlGenerators, shortStringHelper, contentTypeBaseServiceProvider, context, packageMigrationsSettings)
{
    protected override async Task MigrateAsync()
    {
        ImportPackage.FromEmbeddedResource<DefinitionsPackageAction>().Do();

        // Get embedded resources from the assembly
        var assembly = Assembly.GetExecutingAssembly();
        var resourceNames = assembly.GetManifestResourceNames()
            .Where(name => name.Contains("Definitions") && name.EndsWith(".json"));

        foreach (var resourceName in resourceNames)
        {
            // Extract alias from resource name
            var parts = resourceName.Split('.');
            var alias = parts[^2]; // Second to last part (before .json)
            
            // Read the embedded resource
            await using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) continue;
            
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            
            var dto = JsonSerializer.Deserialize<BlockFarmEditorDefinitionDTO>(contents);
            if (dto == null) continue;
            
            var definition = await blockFarmEditorDefinitionService.GetByAliasAsync(Database, alias);
            if (definition != null)
            {
                var user = userService.GetUserById(-1);
                await blockFarmEditorDefinitionService.UpdateAsync(Database, definition.Id, dto.Type, dto.ViewPath, dto.Category, dto.Enabled, user?.Key ?? dto.UpdatedBy);
                logger.LogInformation("Updated definition for alias: {Alias}", alias);
            }
            else
            {
                var user = userService.GetUserById(-1);
                await blockFarmEditorDefinitionService.CreateAsync(Database, dto, user?.Key ?? dto.UpdatedBy);
                logger.LogInformation("Created new definition for alias: {Alias}", alias);
            }
        }
    }
}
