using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exc1.Entity;

namespace Exc1.Model
{
    class UserModel
    {
        private static ObservableCollection<User> listUser;

        public static ObservableCollection<User> GetUser()
        {
            DataModel.InitializeDatabase();

            if (listUser == null)
            {
                listUser = new ObservableCollection<Entity.User>();
            }
            using (SqliteConnection db = new SqliteConnection("Filename= manager.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM users";
                SqliteDataReader sqliteData = selectCommand.ExecuteReader();
                Entity.User user;
                while (sqliteData.Read())
                {
                    user = new Entity.User
                    {
                        Id = Convert.ToInt16(sqliteData["id"]),
                        Name = Convert.ToString(sqliteData["name"]),
                        Email = Convert.ToString(sqliteData["email"]),
                        Phone = Convert.ToString(sqliteData["phone"]),
                        Avatar = Convert.ToString(sqliteData["avatar"]),
                        Address = Convert.ToString(sqliteData["address"]),
                    };
                    listUser.Add(user);
                }
                db.Close();
            }
            if (listUser == null)
            {
                listUser = new ObservableCollection<Entity.User>();
            }
            return listUser;
        }

        public static void SetUser(ObservableCollection<Entity.User> users)
        {
            listUser = users;
        }

        public static void AddUser(Entity.User user)
        {
            DataModel.InitializeDatabase();

            using (SqliteConnection db = new SqliteConnection("Filename= manager.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO users (name, email, phone, address, avatar) VALUES (@name, @email, @phone, @address, @avatar);";
                insertCommand.Parameters.AddWithValue("@name", user.Name);
                insertCommand.Parameters.AddWithValue("@email", user.Email);
                insertCommand.Parameters.AddWithValue("@phone", user.Phone);
                insertCommand.Parameters.AddWithValue("@address", user.Address);
                insertCommand.Parameters.AddWithValue("@avatar", user.Avatar);

                insertCommand.ExecuteReader();

                db.Close();
            }
            if (listUser == null)
            {
                listUser = new ObservableCollection<Entity.User>();
            }
            listUser.Add(user);
        }
    }
}
