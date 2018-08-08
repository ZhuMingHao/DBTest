using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DBTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = string.Empty;

            try
            {
                path = Path.Combine(ApplicationData.Current.GetPublisherCacheFolder("SqLightDataBase").Path, "sqliteSample.db");
            }
            catch (Exception ex)
            {
                
            }

            var sqliteConnectionString = "DataSource=" + path;

            using (SqliteConnection db = new SqliteConnection(sqliteConnectionString))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                                        "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                                        "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }
}
