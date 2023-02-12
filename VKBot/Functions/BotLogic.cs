using VKBot.Models;
using VKBot.Models.MenuFunctions;
using VKBot.Utilities;

namespace VKBot.Functions
{
    public class BotLogic : VKLogic
    {
        public static void BotMain()
        {
            while (true)
            {
                Thread.Sleep(20);
                
                Receive();
            }
        }

        public static bool Receive()
        {
            object[] messageinfo = GetMessage();
            long? userid = Convert.ToInt32(messageinfo[2]);
            string message = "";

            if (CheckBan(userid) == true)
                return false;

            if (messageinfo[0] == null)
                return false;

            if (messageinfo[1].ToString() != "")
                message = messageinfo[1].ToString();
            else
                message = messageinfo[0].ToString();

            Response(message, userid);

            return true;
        }

        public static bool SocialOn = false, SettingsOn = false;
        public static void Response(string message, long? userid)
        {
            if (CheckUser(userid) == false)
            {
                CreateCharacter.NewCharacter(userid, message);
            }
            else if (SocialOn)
            {
                Menu_Social.Get(message, userid);
            }
            else if (SettingsOn)
            {
                Menu_Settings.Get(message, userid);
            }
            else
            {
                Menu.Get(message, userid);
            }
        }
    }
}
