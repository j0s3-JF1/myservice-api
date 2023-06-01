using MySql.Data.MySqlClient;

namespace MyService_API.DAO
{
    public class ConnectionFactory
    {
        public static MySqlConnection Build()
        {
            string connectionstring = "Server=myservice.mysql.database.azure.com;Uid=myservice;Database=MyService_Database;Pwd=#ServiceMy";
            return new MySqlConnection(connectionstring);
        }
    }
}
