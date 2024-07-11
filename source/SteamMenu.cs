using Playnite.SDK;
using Playnite.SDK.Events;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace SteamMenu
{
    public class SteamMenu : GenericPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private SteamMenuSettingsViewModel settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("626f6c31-eac9-421b-bd20-82381da4dde8");

        public SteamMenu(IPlayniteAPI api) : base(api)
        {
            settings = new SteamMenuSettingsViewModel(this);
            Properties = new GenericPluginProperties
            {
                HasSettings = true
            };
        }

        public override void OnGameInstalled(OnGameInstalledEventArgs args)
        {
            // Add code to be executed when game is finished installing.
        }

        public override void OnGameStarted(OnGameStartedEventArgs args)
        {
            // Add code to be executed when game is started running.
        }

        public override void OnGameStarting(OnGameStartingEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameStopped(OnGameStoppedEventArgs args)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameUninstalled(OnGameUninstalledEventArgs args)
        {
            // Add code to be executed when game is uninstalled.
        }

        public override void OnApplicationStarted(OnApplicationStartedEventArgs args)
        {
            // Add code to be executed when Playnite is initialized.
        }

        public override void OnApplicationStopped(OnApplicationStoppedEventArgs args)
        {
            // Add code to be executed when Playnite is shutting down.
        }

        public override void OnLibraryUpdated(OnLibraryUpdatedEventArgs args)
        {
            // Add code to be executed when library is updated.
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new SteamMenuSettingsView();
        }

        private void OpenWebMenu()
        {


            using (var webView = PlayniteApi.WebViews.CreateView(1109, 746))
            {

                webView.Navigate("https://store.steampowered.com/");
                webView.OpenDialog();
            }
        }

        public override IEnumerable<TopPanelItem> GetTopPanelItems()
        {
            yield return new TopPanelItem
            {
                Title = "Calculator",
                Icon = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "steam.png"),
                Activated = () => OpenWebMenu()
            };
        }
    }
}