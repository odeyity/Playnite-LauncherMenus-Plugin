using Playnite.SDK;
using Playnite.SDK.Events;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;


namespace LauncherMenus
{
    public class LauncherMenus : GenericPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private LauncherMenusSettingsViewModel settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("626f6c31-eac9-421b-bd20-82381da4dde8");

        public LauncherMenus(IPlayniteAPI api) : base(api)
        {
            settings = new LauncherMenusSettingsViewModel(this);
            Properties = new GenericPluginProperties
            {
                HasSettings = false
            };
        }

        private void OpenWebMenu(string url)
        {


            using (var webView = PlayniteApi.WebViews.CreateView(1109, 746))
            {

                webView.Navigate(url);
                webView.OpenDialog();
            }
        }

        public override IEnumerable<TopPanelItem> GetTopPanelItems()
        {
            yield return new TopPanelItem
            {
                Title = "Steam Menu",
                Icon = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "steam.png"),
                Activated = () => OpenWebMenu("https://store.steampowered.com/")
            };

            yield return new TopPanelItem
            {
                Title = "Epic Games Menu",
                Icon = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "epic.png"),
                Activated = () => OpenWebMenu("https://store.epicgames.com/")
            };
        }
    }
}