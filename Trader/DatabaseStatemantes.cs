using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Trader
{
    internal class DatabaseStatemantes
    {
        Connect conn = new Connect();

        public object AddNewUser(object user)
        {
            try
            {
                conn._connection.Open();
                var newUser = user.GetType().GetProperties();

                string salt = generatesalt();
            
                string Hashedpassword = computeHmacSha256(newUser[2].GetValue(user).ToString(),salt);

                string sql = "INSERT INTO `users`(`UserName`, `FullName`, `Password`, `Salt`, `Email`) VALUES (@username,@fullname,@password,@salt,@email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn._connection);     

                cmd.Parameters.AddWithValue("@username", newUser[0].GetValue(user));
                cmd.Parameters.AddWithValue("@fullname", newUser[1].GetValue(user));
                cmd.Parameters.AddWithValue("@password",Hashedpassword);
                cmd.Parameters.AddWithValue("@salt",salt);
                cmd.Parameters.AddWithValue("@email", newUser[4].GetValue(user));

                cmd.ExecuteNonQuery();

                conn._connection.Close();

                return new { message = "Sikeres hozzáadás." };
            }
            catch (System.Exception ex)
            {
                return new { message = ex.Message };
            }

        }

        public object LoginUser(object user)
        {
            try
            {


            conn._connection.Open();

            string sql = "SELECT * FROM users WHERE UserName = @username;";

            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);

            var logUser = user.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@username", logUser[0].GetValue(user));
          //  cmd.Parameters.AddWithValue("@password", logUser[1].GetValue(user));

            MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    string storedhash = reader.GetString(3);
                    string storedsalt = reader.GetString(4);
                    string comutehash = computeHmacSha256(logUser[2].GetValue(user).ToString(), storedsalt);

                    return storedhash == comutehash;
                }
            conn._connection.Close();
              
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public DataView userlist() 
        {
            try
            {


            conn._connection.Open();

            string sql = "SELECT * FROM users ";

            MySqlCommand cmd = new MySqlCommand(sql,conn._connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable dt = new DataTable();

            adapter.Fill(dt);  

            conn._connection.Close();

            return dt.DefaultView;
            }
            catch (System.Exception ex)
            {

                return null;
            }
        }
        public string generatesalt() 
        {

            byte[] salt = new byte[16];

            using (var rnd = RandomNumberGenerator.Create()) 
            {           
                rnd.GetBytes(salt);           
            }
        
            return Convert.ToBase64String(salt);
        }

        public string computeHmacSha256(string password, string salt) 
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt))) 
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
