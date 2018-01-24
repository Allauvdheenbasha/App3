using Xamarin.Forms;

using SQLite.Net;
using System.IO;

[assembly: Dependency(typeof(crud_android))]

public class crud_android : ISQLiteCrudd
    {
        public SQLiteConnection getConnection()
        {
            var filename = "Cover1.db3";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
