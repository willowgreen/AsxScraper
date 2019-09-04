using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace AsxScraper
{
    class Database
    {
        private Database()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static Database _instance = null;
        public static Database Instance()
        {
            if (_instance == null)
                _instance = new Database();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                IDictionary<string, string> properties = new Dictionary<string, string>();
                properties["server"] = (System.Configuration.ConfigurationManager.AppSettings["database_hostname"] ?? "localhost") + ":" + (System.Configuration.ConfigurationManager.AppSettings["database_port"] ?? "3306");
                properties["database"] = System.Configuration.ConfigurationManager.AppSettings["database_dbname"] ?? "localhost";
                properties["username"] = System.Configuration.ConfigurationManager.AppSettings["database_username"] ?? "root";
                properties["password"] = System.Configuration.ConfigurationManager.AppSettings["database_password"] ?? "";

                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", properties["server"], properties["database"], properties["username"], properties["password"]);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
