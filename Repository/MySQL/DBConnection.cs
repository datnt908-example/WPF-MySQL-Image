using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.MySQL
{
    public class DBConnection
    {
        private const string connectionStringFormat =
            "server={0};user={1};database={2};port=3306;password={3}";
        private string password = string.Empty;
        private MySqlConnection connection = null;
        private static DBConnection instance = null;

        public string DatabaseName { get; set; }
        public string ServerIP { get; set; }
        public string Username { get; set; }
        public string Password { set { password = value; } }
        public MySqlConnection Connection
        {
            get
            {
                if (connection == null)
                    SetConnecion();
                return connection;
            }
        }

        private DBConnection()
        {
            DatabaseName = string.Empty;
            ServerIP = "127.0.0.1";
            Username = "root";
        }
        public static DBConnection Instance()
        {
            if (instance == null)
                instance = new DBConnection();
            return instance;
        }

        public void SetConnecion()
        {
            string connectionString = string.Format(
                connectionStringFormat, ServerIP, Username, DatabaseName, password);
            connection = new MySqlConnection(connectionString);
        }
    }
}
