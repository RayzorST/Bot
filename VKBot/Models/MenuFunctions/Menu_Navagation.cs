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
                        int NumberSector = SpaceTravel.CheckSectorNear(userid, message);

                        if (NumberSector != -1)
                        {
                            if(message.ToLower() == "noname")
                            {
                                Menus.Menu_NewSector();
                                SendMessage("New sector",
                                    userid, keyboardbuilder.Build());
                                SQLLogic.Update("userinfo", "Menu='Navigation menu/maneuver/newsector'", $"UserID={userid}");

                                SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
                                string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

                                SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
                                string[] Sectors = (Convert.ToString(SQLLogic.command.ExecuteScalar())).Split("/");

                                string SectorsNames = "";

                                for (int i = 0; i < Sectors.Length - 1; i++)
                                {
                                    if (i != NumberSector)
                                        SectorsNames += Sectors[i] + "/";
                                    else
                                        SectorsNames += "NewSector/";
                                }

                                SQLLogic.Update("sectors", $"SectorsNames='{SectorsNames}'", $"SectorName='{Sector}'");
                            }
                            else
                            {
                                SpaceTravel.GoTo(message, userid);
                            }
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
                    if (SQLLogic.SearchCount("sectors", "SectorName", message) != 0)
                    {
                        SpaceTravel.GoTo(message, userid);
                    }
                    else
                    {
                        //error
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
