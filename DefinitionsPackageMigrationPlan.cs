using BlockFarmEditor.Umbraco.Core.DTO;
using BlockFarmEditor.Umbraco.Database.BlockFarmEditorDefinitions;
using Umbraco.Cms.Core.Packaging;

namespace BlockFarmEditor.Bootstrap.Package;

/// <summary>
/// Migration plan for the BlockFarmEditor definitions package.
/// </summary>
/// <remarks>
/// This migration plan is used to define the migration steps for the BlockFarmEditor definitions package.
/// It is registered in the Umbraco CMS to ensure that the package can be migrated correctly.
/// </remarks>

internal class DefinitionsPackageMigrationPlan : PackageMigrationPlan
{
    public DefinitionsPackageMigrationPlan() : base("BlockFarmEditor Bootstrap Scheme")
    {
    }

    protected override void DefinePlan()
    {
        // Defines the migration steps for the BlockFarmEditor definitions package
        // This migration depends on the main BlockFarmEditor migration to be completed first
        // Starting from the final state of the main BlockFarmEditor migration ensures dependencies are met
        From($"")
        .To<BlockFarmEditorDefinitionTable>($"{BlockFarmEditorDefinitionDTO.TableName}-db")
        .To<DefinitionsPackageAction>(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));
    }

    /// <summary>
    /// Indicates whether the current state of the package should be ignored during migration.
    /// This is set to false to ensure that the migration plan is only applied once and does not re-run on subsequent migrations.
    /// </summary>
    public override bool IgnoreCurrentState => false;
}