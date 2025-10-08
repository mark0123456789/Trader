using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trader
{
    internal class DatabaseStatemantes
    {
        Connect conn = new Connect();

        public object addNewUser(object user)
        {
            try
            {

           
            conn._Connection.Open();

            string sql = $"INSERT INTO `users`(`Username`, `Fullname`, `PASSWORD`, `Salt`, `Email`) VALUES(@username,@fullname,@password,@salt,@email)";

            MySqlCommand cmd = new MySqlCommand(sql, conn._Connection);

            var newuser = user.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@username", newuser[0].GetValue(user));
            cmd.Parameters.AddWithValue("@fullname", newuser[2].GetValue(user));
            cmd.Parameters.AddWithValue("@password", newuser[1].GetValue(user));
            cmd.Parameters.AddWithValue("@salt", newuser[3].GetValue(user));
            cmd.Parameters.AddWithValue("@email", newuser[4].GetValue(user));

            cmd.ExecuteNonQuery();

            conn._Connection.Close();    
        
        return new { message = "sikeres hozzáadás."};

            }
            catch (System.Exception ex)
            {

               return new { message = ex.Message };
            }
        }
    }
}
