using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trader
{
    internal class Connect
    {
        public MySqlConnection _connection;

        private string _host;
        private string _db;
        private string _user;
        private string _password;

        private string _connectionString;
        public Connect()
        {
            _host = "localhost";
            _db = "trader";
            _user = "root";
            _password = "";

            _connectionString = $"SERVER={_host};DATABASE={_db};UID={_user};PASSWORD={_password};SslMode=None";

            _connection = new MySqlConnection(_connectionString);
        }

    }
}
