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

        public static int CheckSectorNear(long? userid, string message)
        {
            SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
            string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
            string[] Sectors = (Convert.ToString(SQLLogic.command.ExecuteScalar())).Split("/");

            for(int i = 0; i < Sectors.Length; i++)
            {
                if(message.ToLower() == Sectors[i].ToLower() + " " + i) { return i; }
            }
            return -1;
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
            SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
            string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
            string[] Sectors = (Convert.ToString(SQLLogic.command.ExecuteScalar())).Split("/");

            int NumberSector = -1;

            for (int i = 0; i < Sectors.Length; i++)
            {
                if ("newsector" == Sectors[i].ToLower()) { NumberSector = i; }
            }

            if (NumberSector != -1)
            {
                string SectrosNames = "";

                for (int i = 0; i < Sectors.Length - 1; i++)
                {
                    if (i != NumberSector)
                        SectrosNames += Sectors[i] + "/";
                    else
                        SectrosNames += message + "/";
                }

                SQLLogic.Update("sectors", $"SectorsNames='{SectrosNames}'", $"SectorName='{Sector}'");
            }
            else
            {

            }   
        }
    }
}
