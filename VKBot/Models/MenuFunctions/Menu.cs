using VKBot.Functions;
using VKBot.Utilities;

namespace VKBot.Models.MenuFunctions
{
    public class Menu : VKLogic
    {
        public static void Get(string message, long? userid, string[] menu)
        {
            switch (message.ToLower())
            {
                default:
                    SendMessage("Речь не распознана",
                        userid, keyboardbuilder.Build());
                    goto case "команды";

                case "навигация":
                    SQLLogic.Update("userinfo", "Menu='Navigation menu'", $"UserID={userid}");
                    Menus.Menu_Navigation();
                    SendMessage("Вот мои возможности:",
                        userid, keyboardbuilder.Build());
                    break;

                case "команды":
                    Menus.Menu();
                    SendMessage("Вот мои возможности:",
                        userid, keyboardbuilder.Build());
                    break;

                case "взаимоотношения":
                    SQLLogic.Update("userinfo", "Menu='Social menu'", $"UserID={userid}");
                    Menus.Menu_Social();
                    SendMessage("Чтобы перевести кредиты другому игроку напишите: [игровой ID] [сумма] ",
                       userid, keyboardbuilder.Build());
                    break;

                case "настройки":
                    SQLLogic.Update("userinfo", "Menu='Settings menu'", $"UserID={userid}");
                    Menus.Menu_Settings();
                    SendMessage("Настройки",
                       userid, keyboardbuilder.Build());
                    break;
            }
        }
    }
}
