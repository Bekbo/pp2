using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    public class User
    {
        public string login;
        public string password;

        public User() { }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            string s = Console.ReadLine();
            int n = Convert.ToInt32(s);
            string login = null, password = null;
            List<User> users = new List<User>();
            User user = new User();
            if (n == 1)
            {
                Console.WriteLine("Введите логин");
                login = Console.ReadLine();
                Console.WriteLine("Введите пароль");
                password = Console.ReadLine();
                
                user.login = login;
                user.password = password;
                users.Add(user);
                Save(users);
                Console.WriteLine("Registered!");
            }
            if (n == 2)
            {
                FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer xs = new XmlSerializer(typeof(List<User>));
                users = xs.Deserialize(fs) as List<User>;
                fs.Close();
                Console.WriteLine("Введите логин");
                login = Console.ReadLine();
                Console.WriteLine("Введите пароль");
                password = Console.ReadLine();
                bool log = false;
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].login == login && users[i].password == password)
                    {
                        log = true;
                    }
                }
                if (log)
                {
                    Console.WriteLine("Welcome");
                }
                else
                {
                        Console.WriteLine("Incorrect login or password");
                }
            }
            Console.ReadKey();
        }
        public static void Save(List<User> users)
        {
            FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(List<User>));
            xs.Serialize(fs, users);
            fs.Close();
        }
    }
}
