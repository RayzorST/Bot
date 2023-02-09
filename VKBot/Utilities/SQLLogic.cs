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

        static int ConnectionAttempts = 0;
        public static void InitializationServer()
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                Console.WriteLine($"[log] [{DateTime.Now}] Connection with the server ({Resources.ResourceManager.GetString("Data Source")}) is open");
            }
            catch
            {
                Console.WriteLine($"[log] [{DateTime.Now}] Connection with the server ({Resources.ResourceManager.GetString("Data Source")}) is not open");
                ConnectionAttempts++;
                if (ConnectionAttempts != 5)
                {
                    InitializationServer();
                    Console.WriteLine($"[log] Attempt to connect: {ConnectionAttempts}");
                }
            }
        }

        public static int SearchCount(string from, string where, string comparison)
        {
            command.CommandText = String.Format($"SELECT COUNT(*) FROM {from} WHERE {where}={comparison};" );
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count;
        }

        public static void Search(bool criterion, string item, string from, string where, string comparison)
        {
            if(criterion)
                command.CommandText = String.Format($"SELECT {item} FROM {from} WHERE {where}={comparison};");
            else
                command.CommandText = String.Format($"SELECT {item} FROM {from};");
        }

        public static void Update(string from, string set, string where)
        {
            command.CommandText = String.Format($"UPDATE {from} SET {set} WHERE {where};");
            command.ExecuteScalar();
            Console.WriteLine($"[log] [{DateTime.Now}] Information in {from} update on {set} where {where}");
        }

        public static void Insert(bool allValues, string into, string setvalue, string value = null)
        {
            if(allValues)
                command.CommandText = String.Format($"INSERT INTO {into} VALUES ({setvalue});");
            else
                command.CommandText = String.Format($"INSERT INTO {into} ({value}) VALUES ({setvalue});");
            command.ExecuteScalar();
            Console.WriteLine($"[log] [{DateTime.Now}] Information in {into} insert {setvalue} where {value}");
        }
    }
}
