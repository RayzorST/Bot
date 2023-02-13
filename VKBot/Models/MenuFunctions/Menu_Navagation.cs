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
                if (menu[1] == "maneuver")
                {

                }
                else if (menu[1] == "hyperleap")
                {
                    switch (message)
                    {
                        case "назад":
                            Menus.Menu_Navigation();
                            SendMessage("меню",
                            userid, keyboardbuilder.Build());
                            SQLLogic.Update("userinfo", "Menu='Navigation menu'", $"UserID={userid}");
                            break;
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
                        Menus.Menu_Hyperleap();
                        SendMessage("гиперпрыжок",
                            userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu='Navigation menu/hyperleap'", $"UserID={userid}");
                        break;

                    case "манёвр":
                        Menus.Menu_Maneuver(userid);
                        SendMessage("Манёвр",
                            userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu='Navigation menu/maneuver'", $"UserID={userid}");
                        break;

                    case "сектор":
                        SpaceTravel.GetSector(userid);
                        break;

                    case "назад":
                        Menus.Menu();
                        SendMessage("назад",
                       userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu=''", $"UserID={userid}");
                        break;
                }
            }
        }
    }
}
