using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Database1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            database databaseobject = new database();
            string query = "INSERT INTO Students ('ID', 'StudentName', 'StudentScore') VALUES (@ID,@StudentName,@StudentScore)";
            SQLiteCommand mycommand = new SQLiteCommand(query, databaseobject.myconnection);
            databaseobject.OpenConnection();
            mycommand.Parameters.AddWithValue("@ID", "5");
            mycommand.Parameters.AddWithValue("@StudentName", "Bekbolat");
            mycommand.Parameters.AddWithValue("@StudentScore", "100");
            var result = mycommand.ExecuteNonQuery();
            databaseobject.CloseConnection();
            Console.WriteLine("Rows added : {0}", result);
            Console.ReadKey();
            */
            database databaseobject = new database();
            string query = "Select * FROM Students";
            SQLiteCommand mycommand = new SQLiteCommand(query, databaseobject.myconnection);
            databaseobject.OpenConnection();
            SQLiteDataReader result = mycommand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine("ID - {2}  - Student :{0} - Score {1}", result["StudentName"],
                        result["StudentScore"], result["ID"]);
                }
            }
            databaseobject.CloseConnection();
            Console.ReadKey();
        }
    }
}
