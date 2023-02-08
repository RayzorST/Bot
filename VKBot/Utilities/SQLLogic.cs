using MySql.Data.MySqlClient;

namespace VKBot.Utilities
{
    public class SQLLogic
    {
        public static MySqlCommand command = new MySqlCommand();
        public static MySqlConnection connection = new MySqlConnection(
            $"Database = {Resources.ResourceManager.GetString("Database")}; " +
            $"Data Source = {Resources.ResourceManager.GetString("Data Source")}; " +
            $"Username = {Resources.ResourceManager.GetString("Username")}; " +
            $"Password = {Resources.ResourceManager.GetString("Password")}; " +
            $"Port = {Resources.ResourceManager.GetString("Port")}; " +
            $"CharSet = {Resources.ResourceManager.GetString("CharSet")}");

        public static void InitializationServer()
        {
            connection.Open();
            command.Connection = connection;
        }

        public static void SearchCount(string from, string where, string comparison)
        {
            command.CommandText = String.Format($"SELECT COUNT(*) FROM {from} WHERE {where}={comparison};" );
        }

        public static void Search(bool criterion, string item, string from, string where, string comparison)
        {
            if(criterion)
                command.CommandText = String.Format($"SELECT {item} FROM {from} WHERE {where}={comparison};");
            else
                command.CommandText = String.Format($"SELECT {item} FROM {from};");
        }

        public static void Insert(bool allValues, string into, string setvalue, string value = null)
        {
            if(allValues)
                command.CommandText = String.Format($"INSERT INTO {into} VALUES ({setvalue});");
            else
                command.CommandText = String.Format($"INSERT INTO {into} ({value}) VALUES ({setvalue});");
            command.ExecuteScalar();
        }
    }
}
