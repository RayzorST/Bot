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
            //SQLLogic.Search(true, "Sector", "userinfo", "UserID", userid.ToString());
            //string sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            //SQLLogic.Search(false, "SectorName", "sectors", null, null);
            //string name = Convert.ToString(SQLLogic.command.ExecuteScalar());

            //SQLLogic.Search(false, "Routes", "sectors", null, null);
            //int routes = Convert.ToInt32(SQLLogic.command.ExecuteScalar());

            //VKLogic.SendMessage($"Название сектора {name}\nКол-во ближайших секторов {routes}", userid, null);
        }

        public static void GoTo(string SectorName)
        {

            try
            {
                SQLLogic.Update("userinfo", $"Sector='{SectorName}'", "Sector");
            }
            catch
            {

            }
        }
    }
}
