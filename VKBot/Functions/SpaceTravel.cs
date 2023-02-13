using VKBot.Models;
using VKBot.Utilities;

namespace VKBot.Functions
{
    public class SpaceTravel
    {
        public static void GetSectors()
        {
            //SQLLogic.Search(false, "SectorName", "sectors", null, null);
            //string[] Sectors = Convert.ToString(SQLLogic.command.ExecuteScalar()).Split("/");
        }

        public static void GetSector(long? userid)
        {
            //SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
            //string sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            //string name = Convert.ToString(SQLLogic.command.ExecuteScalar());

            //SQLLogic.Search(false, "Routes", "sectors", null);
            //int routes = Convert.ToInt32(SQLLogic.command.ExecuteScalar());

            //VKLogic.SendMessage($"Название сектора {name}\nКол-во ближайших секторов {routes}", userid, null);
        }

        public static bool CheckSector(long? userid, string message)
        {
            SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
            string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
            string[] Sectors = (Convert.ToString(SQLLogic.command.ExecuteScalar())).Split("/");

            for(int i = 0; i < Sectors.Length; i++)
            {
                if(message.ToLower() == Sectors[i].ToLower() + " " + i) { return true; }
            }
            return false;
        }

        public static void GoTo(string SectorName, long? userid)
        {

            try
            {
                SQLLogic.Update("userinfo", $"Sector='{SectorName}'", $"UserID={userid}");
            }
            catch
            {

            }
        }

        public static void NewSector(string message, long? userid)
        {
            
        }
    }
}
