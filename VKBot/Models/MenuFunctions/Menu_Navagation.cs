using VKBot.Functions;
using VKBot.Utilities;

namespace VKBot.Models.MenuFunctions
{
    internal class Menu_Navagation : VKLogic
    {
        public static void Get(string message, long? userid, string[] menu)
        {
            if (menu.Length > 1 && menu[1] == "maneuver")
            {
                if (menu.Length > 2 && menu[2] == "newsector")
                {
                    if ((message.ToLower() == "назад"))
                    {
                        Menus.Menu_Navigation();
                        SendMessage("меню",
                            userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu='Navigation menu/maneuver'", $"UserID={userid}");
                    }
                    else
                    {
                        SpaceTravel.NewSector(message, userid);
                    }
                }
                else
                {
                    if ((message.ToLower() == "назад"))
                    {
                        Menus.Menu_Navigation();
                        SendMessage("меню",
                            userid, keyboardbuilder.Build());
                        SQLLogic.Update("userinfo", "Menu='Navigation menu'", $"UserID={userid}");
                    }
                    else
                    {
                        if (SpaceTravel.CheckSector(userid, message))
                        {
                            Menus.Menu_NewSector();
                            SendMessage("New sector",
                                userid, keyboardbuilder.Build());
                            SQLLogic.Update("userinfo", "Menu='Navigation menu/maneuver/newsector'", $"UserID={userid}");
                        }
                        else
                        {
                            SendMessage("Сек",
                                userid, null);
                        }
                    }
                }
            }
            else if (menu.Length > 1 && menu[1] == "hyperleap")
            {
                if ((message.ToLower() == "назад"))
                {
                    Menus.Menu_Navigation();
                    SendMessage("меню",
                        userid, keyboardbuilder.Build());
                    SQLLogic.Update("userinfo", "Menu='Navigation menu'", $"UserID={userid}");
                }
                else
                {

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
