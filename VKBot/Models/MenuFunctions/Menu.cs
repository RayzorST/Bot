using VKBot.Functions;
using VKBot.Utilities;

namespace VKBot.Models.MenuFunctions
{
    public class Menu : VKLogic
    {
        public static void Get(string message, long? userid)
        {
            switch (message.ToLower())
            {
                default:
                    SendMessage("Речь не распознана",
                        userid, keyboardbuilder.Build());
                    goto case "команды";

                case "перелет":
                    break;

                case "передать":
                    break;

                case "сектор":
                    SpaceTravel.GetSector(userid);
                    goto case "команды";

                case "команды":
                    Menus.Menu();
                    SendMessage("Вот мои возможности:",
                        userid, keyboardbuilder.Build());
                    break;

                case "взаимоотношения":
                    BotLogic.SocialOn = true;
                    keyboardbuilder.Clear();
                    SendMessage("Чтобы перевести кредиты другому игроку напишите: [игровой ID] [сумма] ",
                       userid, keyboardbuilder.Build());
                    break;

                case "настройки":
                    BotLogic.SettingsOn = true;
                    Menus.Menu_Settings();
                    SendMessage("Настройки",
                       userid, keyboardbuilder.Build());
                    break;
            }
        }
    }
}
