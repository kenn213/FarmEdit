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
using System.Diagnostics;
using System.IO;
using System.Xml;


namespace FarmEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReloadSavesPanel();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void DisableAllTabs()
        {
            tiAbout.IsEnabled = false;
            tiGame.IsEnabled = false;
            tiSaves.IsEnabled = false;
            tiSettings.IsEnabled = false;
        }

        private void EnableAllTabs()
        {
            tiAbout.IsEnabled = true;
            tiGame.IsEnabled = true;
            tiSaves.IsEnabled = true;
            tiSettings.IsEnabled = true;
        }

        private void ReloadSavesPanel()
        {

            string[] files = Directory.GetDirectories(Properties.Settings.Default.fs_17_save_folder, "savegame*", SearchOption.AllDirectories);
            
            int count = 0;
            SavesPanelGrid.Children.Clear();
            SavesPanelGrid.RowDefinitions.Clear();
            foreach (string file in files)
            {
                count++;
                XmlDocument doc = new XmlDocument();
                doc.Load(Properties.Settings.Default.fs_17_save_folder + @"\savegame" + count.ToString() + @"\careerSavegame.xml");

                XmlNode node = doc.DocumentElement.SelectSingleNode("/careerSavegame/settings/savegameName");
                string saveGameName = node.InnerText;
                node = doc.DocumentElement.SelectSingleNode("/careerSavegame/settings/mapTitle");
                string mapTitle = node.InnerText;
                node = doc.DocumentElement.SelectSingleNode("/careerSavegame/settings/saveDate");
                string saveDate = node.InnerText;

                Controls.SavesListItem item = new Controls.SavesListItem();

                item.SetValue(Grid.RowProperty, count - 1);
                if (count == 1)
                {
                    item.Margin = new Thickness(5,5,5,8);
                }
                else
                {
                    item.Margin = new Thickness(5,0,5,8);
                }
                item.tbCount.Text = "#" + count;
                item.tbTitle.Text = saveGameName;
                item.tbMap.Text = mapTitle;
                item.tbDate.Text = saveDate;
                item.btn.Click += new RoutedEventHandler(LoadSingleSave_Click);
                item.btn.Name = "savegame" + count.ToString();
                SavesPanelGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });
                SavesPanelGrid.Children.Add(item);
                
            }
        }

        private void LoadSingleSavePanel(String saveGameNum)
        {
            // Clear the saves panel
            SavesPanelGrid.Children.Clear();
            // Clear the saves panel's row definitions
            SavesPanelGrid.RowDefinitions.Clear();
            // Add 1 new row definition
            SavesPanelGrid.RowDefinitions.Add(new RowDefinition
            {
                Height = GridLength.Auto
            });
            

            // Create a new single save display
            Controls.SingleSave item = new Controls.SingleSave(saveGameNum);
            
            //item.tbTitle.Text = saveGameName;
            item.btnBack.Click += new RoutedEventHandler(BackToSaves_Click);
            // Add it to the grid
            SavesPanelGrid.Children.Add(item);
            
        }

        private void BackToSaves_Click(object sender, RoutedEventArgs e)
        {
            ReloadSavesPanel();
        }

        private void LoadSingleSave_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            LoadSingleSavePanel(btn.Name);
        }

        private void tiSaves_GotFocus(object sender, RoutedEventArgs e)
        {
            //ReloadSavesPanel();
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
