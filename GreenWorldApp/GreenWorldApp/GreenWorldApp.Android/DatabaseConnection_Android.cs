using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using GreenWorldApp.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace GreenWorldApp.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "ProductsDatabase.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
           dbName);
            return new SQLiteConnection(path);
        }
    }

}