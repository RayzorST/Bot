using VKBot.Functions;
using VKBot.Utilities;

namespace VKBot.Models.MenuFunctions
{
    internal class Menu_Social : VKLogic
    {
        public static void Get(string message, long? userid)
        {
            switch (message.ToLower())
            {
                default:
                    break;

                case "назад":
                    BotLogic.SocialOn = false;
                    Menus.Menu();
                    SendMessage("Речь не распознана",
                        userid, keyboardbuilder.Build());
                    break;

                case "передать кредиты":
                    string[] infomessage = message.Split(" ");
                    Simplest.SendMoney(userid, infomessage[0], infomessage[1]);
                    break;
            }
        }
    }
}
