using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Database1
{
    class database
    {
        public SQLiteConnection myconnection;

        public database()
        {
            myconnection = new SQLiteConnection("Data Source=database.db");
            if (!File.Exists("database.db")){
                SQLiteConnection.CreateFile("database.db");
                Console.WriteLine("Database File created");
            }
        }

        public void OpenConnection()
        {
            if (myconnection.State != System.Data.ConnectionState.Open)
                myconnection.Open();
        }

        public void CloseConnection()
        {
            if (myconnection.State != System.Data.ConnectionState.Closed)
                myconnection.Close();
        }
    }
}
