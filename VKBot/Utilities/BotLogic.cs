namespace VKBot.Utilities
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

            object[] messageinfo = VKLogic.GetMessage();
            long? userid = Convert.ToInt32(messageinfo[2]);
            string message = "";

            if (messageinfo[0] == null)
                return false;

            if (messageinfo[1].ToString() != "")
                message = messageinfo[1].ToString();
            else
                message = messageinfo[0].ToString();

            Response(message, userid);

            return true;
        }

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
            else
            {
                switch (message)
                {
                    default:
                        break;
                }
            }
        }
    }



    class CreateCharacter : VKLogic
    {
        static Random random = new Random();

        static string nickname = "";
        static int gender = 0;

        public static int CreateCharacterPart0(long? userid)
        {
            SendMessage("Привествую!\nЯ твой помощник" +
                     "\n\nДай-ка пробью тебя по базе...",
                     userid, keyboardbuilder.Build());
            Thread.Sleep(1000);

            SendMessage($"\n\nТак-так, вот твой уникальный индификатор {userid}.",
                userid, null);
            Thread.Sleep(1000);

            SendMessage($"\nНа счету у тебя 20000 кредитов!",
                userid, null);
            Thread.Sleep(1000);

            SendMessage($"\nХм...",
               userid, null);
            Thread.Sleep(1500);

            keyboardbuilder.AddButton("М", "М", null);
            keyboardbuilder.AddButton("Ж", "Ж", null);
            SendMessage($"\nНо тут нет ни твоего имени, ни пола.\nНачнем с полесднего.",
               userid, keyboardbuilder.Build());

            return 1;
        }

        public static int CreateCharacterPart1(long? userid, string message)
        {
            keyboardbuilder.Clear();
            switch (message)
            {
                default:
                    gender = random.Next(0, 2);
                    break;

                case ("М"):
                    gender = 0;
                    break;

                case ("Ж"):
                    gender = 1;
                    break;
            }
            SendMessage($"\nХорошо.\nТеперь теперь придумай себе имя.",
               userid, keyboardbuilder.Build());
            keyboardbuilder.Clear();
            return 2;
        }

        public static int CreateCharacterPart2(long? userid, string message)
        {
            nickname = message;
            keyboardbuilder.AddButton("Гендер", "гендер", null);
            keyboardbuilder.AddButton("Имя", "имя", null);
            keyboardbuilder.AddLine();
            keyboardbuilder.AddButton("Готово", "готово", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Positive);
            SendMessage($"\nВсе. Я почти занес изменения в базу.\nХочешь что-нибуть изменить?",
               userid, keyboardbuilder.Build());

            return 3;
        }

        public static int CreateCharacterPart3(long? userid, string message)
        {
            switch (message.ToLower())
            {
                default:
                    return 3;

                case "гендер":
                    return 1;

                case "имя":
                    return 2;

                case "готово":
                    SQLLogic.Insert(true, "userinfo", $"{userid.ToString()}, 1, '{nickname}', {userid.ToString()}, 20000, {gender}.", null);
                    keyboardbuilder.Clear();
                    SendMessage($"\nЯ обновил информацию, {nickname}.\nА теперь можем отправиться покорять эту галактику.",
                    userid, keyboardbuilder.Build());
                    return 0;
            }
        }
    }
}
