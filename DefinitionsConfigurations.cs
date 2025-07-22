using BlockFarmEditor.Bootstrap.Package;
using BlockFarmEditor.RCL.Library.Attributes;
using BlockFarmEditor.RCL.Models.ConfigModels;
using BlockFarmEditor.Umbraco.Models;


[assembly: BlockFarmEditorConfiguration("alert", "alertType", typeof(BootstrapColorConfig))]
[assembly: BlockFarmEditorConfiguration("badge", "badgeColor", typeof(BootstrapColorConfig))]
[assembly: BlockFarmEditorConfiguration("collapse", "triggerButtonStyle", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("button", "color", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("collapse", "triggerButtonStyle", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("modal", "modalSize", typeof(ModalSizeConfig))]
[assembly: BlockFarmEditorConfiguration("modal", "triggerButtonStyle", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("offcanvas", "placement", typeof(PlacementConfig))]
[assembly: BlockFarmEditorConfiguration("offcanvas", "triggerButtonStyle", typeof(BootstrapColorConfig))]

[assembly: BlockFarmEditorConfiguration("tabs", "tabStyle", typeof(TabStyleConfig))]
[assembly: BlockFarmEditorConfiguration("tabs", "justification", typeof(JustificationConfig))]

namespace BlockFarmEditor.Bootstrap.Package;

internal class BootstrapColorConfig : IBlockFarmEditorConfig
{
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

internal class ModalSizeConfig : IBlockFarmEditorConfig
{
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

internal class PlacementConfig : IBlockFarmEditorConfig
{
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

internal class TabStyleConfig : IBlockFarmEditorConfig
{
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

internal class JustificationConfig : IBlockFarmEditorConfig
{
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