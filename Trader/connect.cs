using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trader
{
    internal class connect
    {
        public MySqlConnection _Connection;

        private String _host;
        private String _db;
        private String _user;
        private String _password;

        private String _Connectionstring;

        public Connect() {
         _host = "localhost";
        _host = "trader";
            _user = "root";
            _password = "";
        
            _Connectionstring = $"SERVER={_host};DATABASE={_db};UID={_user},PASSWORD={_password};SslMode=None";

            _Connection = new MySqlConnection(_host);
        }
    }
}
