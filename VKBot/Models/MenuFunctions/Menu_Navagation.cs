using VKBot.Functions;
using VKBot.Utilities;

namespace VKBot.Models.MenuFunctions
{
    internal class Menu_Navagation : VKLogic
    {
        public static void Get(string message, long? userid, string[] menu)
        {
            if (menu.Length > 1)
            {
                if (menu[1] == "hyperleap")
                {
                    SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
                    string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

                    SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
                    string[] Sectors = (Convert.ToString(SQLLogic.command.ExecuteScalar())).Split("/");

                    if(message == "назад")
                    {
                        Menus.Menu_Navigation();
                        SendMessage("Меню",
                        userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu='Navigation menu'", $"UserID={userid}");
                    }
                    else if(message == Sectors[0])
                    {
                        if(Sectors[0] == "Noname")
                        {

                        }
                        else
                        {

                        }
                    }
                    else if (message == Sectors[1])
                    {

                    }
                    else if (message == Sectors[2])
                    {

                    }
                    else if (message == Sectors[3])
                    {

                    }
                    else if (message == Sectors[4])
                    {

                    }
                    else if (message == Sectors[5])
                    {

                    }
                    else
                    {

                    }

                }
            }
            else
            {
                switch (message)
                {
                    default:
                        break;

                    case "гиперпрыжок":
                        Menus.Menu_Hyperleap(userid);
                        SendMessage("Гиперпрыжок",
                       userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu='Navigation menu/hyperleap'", $"UserID={userid}");
                        break;

                    case "сектор":
                        SpaceTravel.GetSector(userid);
                        break;

                    case "назад":
                        Menus.Menu();
                        SendMessage("Меню",
                       userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu=''", $"UserID={userid}");
                        break;
                }
            }
        }
    }
}
