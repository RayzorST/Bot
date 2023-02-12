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

        public static void Response(string message, long? userid)
        {
            SQLLogic.Search(true, "Menu", "userinfo", $"UserID={userid}");
            string[] menu = (Convert.ToString(SQLLogic.command.ExecuteScalar())).Split("/");

            SQLLogic.Search(true, "GameReady", "userinfo", $"UserID={userid}");
            int GameReady = Convert.ToInt32(SQLLogic.command.ExecuteScalar());

            if (CheckUser(userid) == false || GameReady == 1)
            {
                CreateCharacter.NewCharacter(userid, message);
            }
            else if (menu[0] == "Navigation menu")
            {
                Menu_Navagation.Get(message, userid, menu);
            }
            else if (menu[0] == "Social menu")
            {
                Menu_Social.Get(message, userid);
            }
            else if (menu[0] == "Settings menu")
            {
                Menu_Settings.Get(message, userid);
            }
            else
            {
                Menu.Get(message, userid, menu);
            }
        }
    }
}
