using BlockFarmEditor.Umbraco.Core.DTO;
using BlockFarmEditor.Umbraco.Database.BlockFarmEditorDefinitions;
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

[Weight(100)]
internal class DefinitionsPackageMigrationPlan : PackageMigrationPlan
{
    public DefinitionsPackageMigrationPlan() : base("BlockFarmEditor Bootstrap Scheme")
    {
    }

    protected override void DefinePlan()
    {
        // Defines the migration steps for the BlockFarmEditor definitions package
        // This migration can start from either empty state (fresh install) or after main migration
        // The DefinitionsPackageAction will handle checking if tables exist before proceeding
        From(string.Empty)
        .To<DefinitionsPackageAction>(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));
    }

    /// <summary>
    /// Indicates whether the current state of the package should be ignored during migration.
    /// This is set to true to allow the migration to run regardless of current state.
    /// </summary>
    public override bool IgnoreCurrentState => true;
}