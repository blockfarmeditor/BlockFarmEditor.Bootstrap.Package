using BlockFarmEditor.Umbraco.Database.BlockFarmEditorDefinitions;
using BlockFarmEditor.Umbraco.Database.BlockFarmEditorLayouts;
using Umbraco.Cms.Core.Composing;
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
        // The first step is to create the BlockFarmEditorDefinitionTable.  This should already exist, but this ensures it is created if it does not.
        From($"")
        .To<BlockFarmEditorDefinitionTable>($"{BlockFarmEditorDefinitionTable.TableName}-db")
        .To<DefinitionsPackageAction>(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));
    }

    /// <summary>
    /// Indicates whether the current state of the package should be ignored during migration.
    /// This is set to false to ensure that the migration plan is only applied once and does not re-run on subsequent migrations.
    /// </summary>
    public override bool IgnoreCurrentState => false;
}