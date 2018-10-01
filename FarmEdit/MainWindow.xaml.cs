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
using System.Windows.Navigation;
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
        private void ReloadSavesPanel()
        {
            string[] files = Directory.GetDirectories(Properties.Settings.Default.fs_17_save_folder, "savegame*", SearchOption.AllDirectories);
            
            int count = 0;
            spSavesList.Children.Clear();
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
                TextBlock tbTitle1 = new TextBlock
                {
                    Text = "#" + count + " ",
                    FontSize = 22,
                    Foreground = new SolidColorBrush(Colors.White),
                    Background = new SolidColorBrush(Colors.Black),
                    Padding = new Thickness(5)
                    
                };
                tbTitle1.SetValue(Grid.RowProperty, 0);
                tbTitle1.SetValue(Grid.ColumnProperty, 0);
                TextBlock tbTitle2 = new TextBlock
                {
                    Text = saveGameName,
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    Padding = new Thickness(5)
                };
                tbTitle2.SetValue(Grid.RowProperty, 0);
                tbTitle2.SetValue(Grid.ColumnProperty, 1);
                TextBlock tbTitle3 = new TextBlock
                {
                    Text = "  " + mapTitle + "     " + saveDate,
                    FontSize = 14,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Padding = new Thickness(10)
                };
                tbTitle3.SetValue(Grid.RowProperty, 0);
                tbTitle3.SetValue(Grid.ColumnProperty, 2);
                Grid btnGrid = new Grid
                {
                    
                };
                RowDefinition defaultRow = new RowDefinition();
                btnGrid.RowDefinitions.Add(defaultRow);
                ColumnDefinition defaultCol = new ColumnDefinition();
                btnGrid.ColumnDefinitions.Add(defaultCol);
                defaultCol = new ColumnDefinition();
                btnGrid.ColumnDefinitions.Add(defaultCol);
                defaultCol = new ColumnDefinition();
                
                btnGrid.ColumnDefinitions.Add(defaultCol);
                btnGrid.Children.Add(tbTitle1);
                btnGrid.Children.Add(tbTitle2);
                btnGrid.Children.Add(tbTitle3);
                StackPanel spTitle = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
                //spTitle.Children.Add(tbTitle1);
                //spTitle.Children.Add(tbTitle2);
                //spTitle.Children.Add(tbTitle3);
                Button button = new Button
                {
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Content = btnGrid,
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(2),
                    Margin = new Thickness(5,5,5,0),
                    Name = "savegame" + count.ToString()
                };
                button.Click += new RoutedEventHandler(LoadSingleSave_Click);
                spSavesList.Children.Add(button);
            }
        }
        private void LoadSingleSavePanel(String saveGameNum)
        {

            spSavesList.Children.Clear();
            Button button = new Button
            {
                HorizontalContentAlignment = HorizontalAlignment.Left,
                Content = "Back to Saves List",
                Margin = new Thickness(5)
            };
            button.Click += new RoutedEventHandler(BackToSaves_Click);
            spSavesList.Children.Add(button);
        }
        // In event method.
        private void BackToSaves_Click(object sender, RoutedEventArgs e)
        {
            ReloadSavesPanel();
        }
        // In event method.
        private void LoadSingleSave_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            LoadSingleSavePanel(btn.Name);
            /*
            for (int i = 0; i < counter; i++)
            {
                if (btn.Name == ("Butt" + i))
                {
                    // When find specific button do what do you want.
                    //Then exit from loop by break.
                    break;
                }
            } */
        }
        private void tiSaves_GotFocus(object sender, RoutedEventArgs e)
        {
            ReloadSavesPanel();
        }
    }
}
