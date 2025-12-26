using BlockFarmEditor.Umbraco.Library.Attributes;
using BlockFarmEditor.Umbraco.Models.ConfigModels;
using BlockFarmEditor.Umbraco.Models;
using BlockFarmEditor.Bootstrap.Package;

[assembly: BlockFarmEditorConfiguration("alert", "alertType", typeof(BootstrapColorConfig))]
[assembly: BlockFarmEditorConfiguration("badge", "badgeColor", typeof(BootstrapColorConfig))]
[assembly: BlockFarmEditorConfiguration("collapse", "triggerButtonStyle", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("button", "color", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("modal", "modalSize", typeof(ModalSizeConfig))]
[assembly: BlockFarmEditorConfiguration("modal", "triggerButtonStyle", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("offcanvas", "placement", typeof(PlacementConfig))]
[assembly: BlockFarmEditorConfiguration("offcanvas", "triggerButtonStyle", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("tabs", "tabStyle", typeof(TabStyleConfig))]
[assembly: BlockFarmEditorConfiguration("tabs", "justification", typeof(JustificationConfig))]

[assembly: BlockFarmEditorConfiguration("bootstrapRow", "prefix", typeof(RowPrefixConfig))]
[assembly: BlockFarmEditorConfiguration("bootstrapRow", "rowDirection", typeof(RowDirectionConfig))]

[assembly: BlockFarmEditorConfiguration("bootstrapContainer", "container", typeof(ContainerConfig))]
[assembly: BlockFarmEditorConfiguration("bootstrapContainer", "background", typeof(BootstrapColorConfig))]


namespace BlockFarmEditor.Bootstrap.Package;

public class BootstrapColorConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap color options for dropdowns.
    /// This is used for various components like alerts, badges, buttons, etc.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
                {
                    Alias = "items",
                    Value = new List<DropdownEditorConfigItem>() {
                        new("Primary", "primary"),
                        new("Secondary", "secondary"),
                        new("Success", "success"),
                        new("Danger", "danger"),
                        new("Warning", "warning"),
                        new("Info", "info"),
                        new("Light", "light"),
                        new("Dark", "dark"),
                        new("Link", "link")
                    }
                },
                new ()
                {
                    Alias = "multiple",
                    Value = false
                }
        ]);
    }
}

public class ModalSizeConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap modal size options for dropdowns.
    /// This is used for configuring the size of modals in the Block Farm Editor.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
            {
                Alias = "items",
                Value = new List<DropdownEditorConfigItem>() {
                    new("Default", ""),
                    new("Small", "modal-sm"),
                    new("Large", "modal-lg"),
                    new("Extra Large", "modal-xl"),
                    new("Full Screen", "modal-fullscreen")
                }
            },
            new ()
            {
                Alias = "multiple",
                Value = false
            }
        ]);
    }
}

public class PlacementConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap offcanvas placement options for dropdowns.
    /// This is used for configuring the placement of offcanvas components in the Block Farm Editor.
    /// The options include start, end, top, and bottom placements.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
            {
                Alias = "items",
                Value = new List<DropdownEditorConfigItem>() {
                    new("Start (Left)", "offcanvas-start"),
                    new("End (Right)", "offcanvas-end"),
                    new("Top", "offcanvas-top"),
                    new("Bottom", "offcanvas-bottom")
                }
            },
            new ()
            {
                Alias = "multiple",
                Value = false
            }
        ]);
    }
}

public class TabStyleConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap tab styles for dropdowns.
    /// This is used for configuring the appearance of tabs in the Block Farm Editor.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
                {
                    Alias = "items",
                    Value = new List<DropdownEditorConfigItem>() {
                        new("Tabs", "nav-tabs"),
                        new("Pills", "nav-pills"),
                        new("Underline", "nav-underline")
                    }
                },
                new ()
                {
                    Alias = "multiple",
                    Value = false
                }
        ]);
    }
}

public class JustificationConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap tab justification options for dropdowns.
    /// This is used for configuring the alignment of tabs in the Block Farm Editor.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
                {
                    Alias = "items",
                    Value = new List<DropdownEditorConfigItem>() {
                        new("Default", ""),
                        new("Center", "justify-content-center"),
                        new("End", "justify-content-end")
                    }
                },
                new ()
                {
                    Alias = "multiple",
                    Value = false
                }
        ]);
    }
}


public class RowPrefixConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap tab justification options for dropdowns.
    /// This is used for configuring the alignment of tabs in the Block Farm Editor.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
            {
                Alias = "items",
                Value = new List<DropdownEditorConfigItem>() {
                new("Extra Small (xs)", "col"),
                new("Small (sm)", "col-sm"),
                new("Medium (md)", "col-md"),
                new("Large (lg)", "col-lg"),
                new("Extra Large (xl)", "col-xl"),
                new("Extra Extra Large (xxl)", "col-xxl")
                }
            },
            new ()
            {
                Alias = "multiple",
                Value = false
            }
        ]);
    }
}


public class RowDirectionConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap tab justification options for dropdowns.
    /// This is used for configuring the alignment of tabs in the Block Farm Editor.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
            {
            Alias = "items",
            Value = new List<DropdownEditorConfigItem>() {
            new("Row", "flex-row"),
            new("Row Reverse", "flex-row-reverse"),
            new("Column", "flex-column"),
            new("Column Reverse", "flex-column-reverse")
            }
            },
            new ()
            {
            Alias = "multiple",
            Value = false
            }
        ]);
    }
}

public class ContainerConfig : IBlockFarmEditorConfig
{
    /// <summary>
    /// Returns a list of Bootstrap tab justification options for dropdowns.
    /// This is used for configuring the alignment of tabs in the Block Farm Editor.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<BlockFarmEditorConfigItem>> GetItems()
    {
        return
        Task.FromResult<IEnumerable<BlockFarmEditorConfigItem>>([
            new ()
            {
            Alias = "items",
            Value = new List<DropdownEditorConfigItem>() {
            new("No Container", ""),
            new("Container", "container"),
            new("Container Fluid", "container-fluid"),
            }
            },
            new ()
            {
            Alias = "multiple",
            Value = false
            }
        ]);
    }
}