using MySql.Data.MySqlClient;

namespace MyService_API.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            string connectionstring = "Server=my-service-server.mysql.database.azure.com;Uid=myservice;Database=MyService_Database;Pwd=#Canario83.";
            return new MySqlConnection(connectionstring);
        }
    }
}
