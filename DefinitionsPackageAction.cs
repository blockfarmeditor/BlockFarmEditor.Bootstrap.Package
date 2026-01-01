using BlockFarmEditor.Umbraco.Core.DTO;
using BlockFarmEditor.Umbraco.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Xml.Serialization;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Packaging;

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
        // Imports the main package into your Umbraco installation
        // This will create the necessary configurations for the Bootstrap blocks
        ImportPackage.FromEmbeddedResource<DefinitionsPackageAction>().Do();

        // Get embedded resources from the assembly
        // These resources are expected to be XML files defining BlockFarmEditor definitions
        // The resources should be named in a specific format, e.g., Definitions.{alias}.xml
        // where {alias} is the alias of the definition
        // This will read each resource, deserialize it, and create or update the definitions in the database
        var assembly = Assembly.GetExecutingAssembly();
        var resourceNames = assembly.GetManifestResourceNames()
            .Where(name => name.Contains("Definitions") && name.EndsWith(".xml", StringComparison.OrdinalIgnoreCase));

        // Iterate through each resource name
        foreach (var resourceName in resourceNames)
        {
            try
            {
                // Extract alias from resource name
                var parts = resourceName.Split('.');
                var alias = parts[^2]; // Second to last part (before .xml)

                // Read the embedded resource
                await using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    logger.LogWarning("Resource stream not found for {Resource}", resourceName);
                    continue;
                }

                // Deserialize the XML content into a BlockFarmEditorDefinitionDTO object
                var serializer = new XmlSerializer(typeof(BlockFarmEditorDefinitionDTO));
                BlockFarmEditorDefinitionDTO? dto;
                try
                {
                    dto = serializer.Deserialize(stream) as BlockFarmEditorDefinitionDTO;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to deserialize XML for {Resource}", resourceName);
                    continue;
                }
                if (dto == null) continue;

                // check for an existing definition with the same alias
                // If it exists, update it; if not, create a new one
                var definition = await blockFarmEditorDefinitionService.GetByAliasAsync(Database, alias);
                
                // Gets the system user to set as the creator or updater of the definition
                // This is necessary for auditing purposes and to ensure the definition has a valid user associated with it
                var user = userService.GetUserById(-1);
                if (definition != null)
                {
                    await blockFarmEditorDefinitionService.UpdateAsync(Database, definition.Id, dto.Type, dto.ViewPath, dto.Category, dto.Enabled, user?.Key ?? dto.UpdatedBy);
                    logger.LogInformation("Updated definition for alias: {Alias}", alias);
                }
                else
                {
                    await blockFarmEditorDefinitionService.CreateAsync(Database, dto, user?.Key ?? dto.UpdatedBy);
                    logger.LogInformation("Created new definition for alias: {Alias}", alias);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing embedded definition resource {Resource}", resourceName);
            }
        }
    }
}
