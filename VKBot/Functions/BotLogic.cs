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

            if (VKLogic.CheckBan(userid) == true)
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

        static bool TrySendmoney = false;
        static int command = 0;
        public static void Response(string message, long? userid)
        {
            SQLLogic.SearchCount("userinfo", "UserID", userid.ToString());

            int count = Convert.ToInt32(SQLLogic.command.ExecuteScalar());

            if (count == 0)
            {
                switch (command)
                {
                    case 0:
                        command = CreateCharacter.CreateCharacterPart0(userid);
                        break;
                    case 1:
                        command = CreateCharacter.CreateCharacterPart1(userid, message);
                        break;
                    case 2:
                        command = CreateCharacter.CreateCharacterPart2(userid, message);
                        break;
                    case 3:
                        command = CreateCharacter.CreateCharacterPart3(userid, message);
                        break;
                }
            }
            else if (TrySendmoney)
            {
                string[] infomessage = message.Split(" ");
                Simplest.SendMoney(userid, infomessage[0], infomessage[1]);
                TrySendmoney = false;
                Menu();
                SendMessage("Перевод успешен",
                            userid, keyboardbuilder.Build());
            }
            else
            {
                switch (message.ToLower())
                {
                    default:
                        SendMessage("Речь не распознана",
                            userid, keyboardbuilder.Build());
                        goto case "команды";

                    case "передать":
                        break;

                    case "сектор":
                        SpaceTravel.GetSector(userid);
                        break;

                    case "команды":
                        Menu();
                        SendMessage("Вот мои возможности:",
                            userid, keyboardbuilder.Build());
                        break;

                    case "перевести":
                        TrySendmoney = true;
                        keyboardbuilder.Clear();
                        SendMessage("Чтобы перевести кредиты другому игроку напишите: [игровой ID] [сумма] ",
                           userid, keyboardbuilder.Build());
                        break;
                }
            }
        }

        private static void Menu()
        {
            keyboardbuilder.AddButton("Сектор", "сектор", null);
            keyboardbuilder.AddButton("Перелет", "сектор", null);
            keyboardbuilder.AddLine();
            keyboardbuilder.AddButton("Перевести", "перевести", null);
        }
    }
}
