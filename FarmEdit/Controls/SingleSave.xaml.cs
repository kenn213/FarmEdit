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
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace FarmEdit.Controls
{
    /// <summary>
    /// Interaction logic for SingleSave.xaml
    /// </summary>
    public partial class SingleSave : UserControl
    {
        public SingleSave(string saveGame)
        {
            InitializeComponent();

            XPathDocument saveGameDoc = new XPathDocument(Properties.Settings.Default.fs_17_save_folder + @"\" + saveGame + @"\careerSavegame.xml");

            XPathNavigator nav = saveGameDoc.CreateNavigator();

            XPathNodeIterator xmoney = nav.Select("//money");

            XmlDocument doc = new XmlDocument();
            doc.Load(Properties.Settings.Default.fs_17_save_folder + @"\" + saveGame + @"\careerSavegame.xml");

            // Get specific node data
            XmlNode node = doc.DocumentElement.SelectSingleNode("/careerSavegame/settings/savegameName");
            
            string saveGameName = doc.DocumentElement.SelectSingleNode("/careerSavegame/settings/savegameName").InnerText;
            node = doc.DocumentElement.SelectSingleNode("/careerSavegame/settings/mapTitle");
            string mapTitle = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/careerSavegame/settings/saveDate");
            string saveDate = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/careerSavegame/statistics/money");
            string money = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/careerSavegame/statistics/loan");
            string loan = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/careerSavegame/totalAmounts");




            //foreach (XmlNode thisNode )
            //string[] siloTotals = node;

            // Set page title
            tbTitle.Text = saveGameName;

            // Set General Data
            DataTable generalTable = new DataTable();
            generalTable.Columns.Clear();
            generalTable.Rows.Clear();
            generalTable.Columns.Add("Property", typeof(String));
            generalTable.Columns.Add("Value", typeof(String));

            generalTable.Rows.Add("Map Name", mapTitle);
            generalTable.Rows.Add("Last Saved", saveDate);

            // Set Financial Data
            DataTable financialTable = new DataTable();
            financialTable.Columns.Clear();
            financialTable.Rows.Clear();
            financialTable.Columns.Add("Property", typeof(String));
            financialTable.Columns.Add("Value", typeof(String));

            financialTable.Rows.Add("Current Money", xmoney.Current.Value);
            financialTable.Rows.Add("Current Loan", loan);

            // Set Weather Data
            DataTable weatherTable = new DataTable();
            weatherTable.Columns.Clear();
            weatherTable.Rows.Clear();
            weatherTable.Columns.Add("Weather Type", typeof(String));
            weatherTable.Columns.Add("Starting Day", typeof(String));

            foreach (XmlNode thisNode in doc.DocumentElement.SelectSingleNode("/careerSavegame/environment/rains"))
            {
                string rainType = thisNode.Attributes["rainTypeId"].Value;
                string startDay = thisNode.Attributes["startDay"].Value;

                weatherTable.Rows.Add(rainType, startDay);
            }
            // Set Silo Data
            DataTable siloTable = new DataTable();
            siloTable.Columns.Clear();
            siloTable.Rows.Clear();
            siloTable.Columns.Add("Fill Type", typeof(String));
            siloTable.Columns.Add("Amount", typeof(String));

            foreach (XmlNode thisNode in doc.DocumentElement.SelectSingleNode("/careerSavegame/totalAmounts"))
            {
                string fillType = thisNode.Attributes["fillType"].Value;
                string value = thisNode.Attributes["value"].Value;

                siloTable.Rows.Add(fillType, value);
            }



            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(generalTable);
            dataSet.Tables.Add(financialTable);
            dataSet.Tables.Add(weatherTable);
            dataSet.Tables.Add(siloTable);
            DataView generalDataView = new DataView(dataSet.Tables[0]);
            dgSaveData.ItemsSource = generalDataView;
            DataView financialDataView = new DataView(dataSet.Tables[1]);
            dgFinancialData.ItemsSource = financialDataView;
            DataView weatherDataView = new DataView(dataSet.Tables[2]);
            dgWeatherData.ItemsSource = weatherDataView;
            DataView siloDataView = new DataView(dataSet.Tables[3]);
            dgSiloData.ItemsSource = siloDataView;
        }
    }
}
