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
using System.Windows.Shapes;

namespace WatchParty {
    /// <summary>
    /// Interaction logic for Config.xaml
    /// </summary>
    public partial class Config : Window {
        string currentSource_ = Settings.Default.CurrentSource; // Get current source

        public Config() {
            InitializeComponent();

            // Set window based on current source
            switch (currentSource_) {
                case "SourceMasteranime":
                    SourceSelector.SelectedItem = SourceMasteranime;
                    MaUrlTextBox.Text = Settings.Default.MasteranimeUrl;
                    ATUrlTextBox.Text = Settings.Default.animeTitle;
                    break;
                case "SourceVLC":
                    SourceSelector.SelectedItem = SourceVLC;
                    break;
                default:
                    break;
            }
        }
        
        // Update optons on new selection
        private void SourceSelector_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            currentSource_ = ((ComboBoxItem)SourceSelector.SelectedItem).Name;
        }

        // Apply changes on click
        private void ConfigOkButton_Click(object sender, RoutedEventArgs e) {
            Settings.Default.CurrentSource = currentSource_;

            switch (currentSource_) {
                case "SourceMasteranime":
                    Settings.Default.MasteranimeUrl = MaUrlTextBox.Text;
                    Settings.Default.animeTitle = ATUrlTextBox.Text;
                    break;
                case "SourceVLC":
                    break;
                default:
                    break;
            }
            Settings.Default.Save();
            Close(); // Close window
        }

        // Ignore changes on cancel
        private void ConfigCancelButton_Click(object sender, RoutedEventArgs e) {
            Close();
        }

    }
}
