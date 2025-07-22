using BlockFarmEditor.RCL.Database.BlockFarmEditorDefinitions;
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
        From($"")
        .To<BlockFarmEditorDefinitionTable>($"{BlockFarmEditorDefinitionTable.TableName}-db")
        .To<DefinitionsPackageAction>(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));
    }

    public override bool IgnoreCurrentState => true;
}