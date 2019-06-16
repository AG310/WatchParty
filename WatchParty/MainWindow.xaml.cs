using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WatchParty {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Logger logger;
        bool active = false;
        Website website = null;

        public MainWindow() {
            InitializeComponent();
            logger = new Logger(LogWindow);

            if (Settings.Default.FirstRun) {
                logger.Log("First Run!");
                Settings.Default.FirstRun = false;
                Settings.Default.Save();
            }
        }

        private void StartBot(object sender, RoutedEventArgs e) {
            switch (Settings.Default.CurrentSource) {
                case "SourceMasteranime":
                    if (Settings.Default.MasteranimeUrl.Length == 0) {
                        logger.Log("Set Masteranime URL");
                        return;
                    }
                    if (!active) {
                        StartMasteranime();
                    } else {
                        StopMasteranime();
                    }
                    break;
                default:
                    break;
            }
            if (active) { // Disable
                StartButton.Content = "Start";
                StatusIndicator.Content = "Off";
                StatusIndicator.Foreground = new SolidColorBrush(Colors.Red);
            } else { // Enable
                StartButton.Content = "Stop";
                StatusIndicator.Content = "On";
                StatusIndicator.Foreground = new SolidColorBrush(Colors.Green);
            }
            active = !active;
        }

        private void ConfigButton_Click(object sender, RoutedEventArgs e) {
            Config configWindow = new Config {
                Owner = this
            };
            configWindow.ShowDialog();
        }

        private void StartMasteranime() {
            logger.Log("Starting browser...");
            logger.Log("Url set to: " + Settings.Default.MasteranimeUrl);
            website = new Masteranime();
            website.StartBrowser();

            //logger.Log(website.GetRemainingTime());
        }
        private void StopMasteranime() {
            logger.Log("Stopping browser...");
            website.StopBrowser();
            website = null;
        }
    }
}
