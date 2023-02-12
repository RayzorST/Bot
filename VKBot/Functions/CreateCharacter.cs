using VKBot.Functions;
using VKBot.Models;
using VkNet.Model;

namespace VKBot.Utilities
{
    public class CreateCharacter : VKLogic
    {
        static Random random = new Random();

        static string nickname = "";
        static int gender = 0;
        static int command = 0;

        public static void NewCharacter(long? userid, string message)
        {
            SQLLogic.Search(true, "CreationStage", "userinfo", $"UserID={userid}");
            command = Convert.ToInt32(SQLLogic.command.ExecuteScalar());

            switch (command)
            {
                case 0:
                    command = CreateCharacterPart0(userid);
                    break;
                case 1:
                    command = CreateCharacterPart1(userid, message);
                    break;
                case 2:
                    command = CreateCharacterPart2(userid, message);
                    break;
                case 3:
                    command = CreateCharacterPart3(userid, message);
                    break;
                case 4:
                    command = ChangeGender(userid, message);
                    break;
                case 5:
                    command = ChangeNickname(userid, message);
                    break;
            }
        }

        private static int CreateCharacterPart0(long? userid)
        {
            keyboardbuilder.Clear();

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

            SQLLogic.Insert(true, "userinfo", $"{userid}, 1,'Noname', '{userid}', 20000, 0, 'Prosperity', '', 1, 1");

            return 1;
        }

        private static int CreateCharacterPart1(long? userid, string message)
        {
            keyboardbuilder.Clear();

            switch (message)
            {
                default:
                    return 1;

                case "М":
                    gender = 0;
                    break;

                case "Ж":
                    gender = 1;
                    break;
            }
            SendMessage($"\nХорошо.\nТеперь теперь придумай себе имя.",
               userid, keyboardbuilder.Build());
            keyboardbuilder.Clear();

            SQLLogic.Update("userinfo", $"Gender={gender}", $"UserID={userid}");
            SQLLogic.Update("userinfo", $"CreationStage=2", $"UserID={userid}");

            return 2;
        }

        private static int CreateCharacterPart2(long? userid, string message)
        {
            keyboardbuilder.Clear();

            nickname = message;
            if(nickname.Length <= 20 && nickname.Length >= 3)
            {
                keyboardbuilder.AddButton("Гендер", "гендер", null);
                keyboardbuilder.AddButton("Имя", "имя", null);
                keyboardbuilder.AddLine();
                keyboardbuilder.AddButton("Готово", "готово", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Positive);
                SendMessage($"\nВсе. Я почти занес изменения в базу.\nХочешь что-нибуть изменить?",
                   userid, keyboardbuilder.Build());

                SQLLogic.Update("userinfo", $"Nickname='{nickname}'", $"UserID={userid}");
                SQLLogic.Update("userinfo", $"CreationStage=3", $"UserID={userid}");

                return 3;
            }
            else
            {
                SendMessage($"\nВ имени должно быть от 3 до 20 символов",
                   userid, null);
                return 2;
            }
        }

        private static int CreateCharacterPart3(long? userid, string message)
        {
            keyboardbuilder.Clear();

            switch (message.ToLower())
            {
                default:
                    return 3;

                case "гендер":
                    keyboardbuilder.AddButton("М", "М", null);
                    keyboardbuilder.AddButton("Ж", "Ж", null);
                    SendMessage($"Выбери пол",
                       userid, keyboardbuilder.Build());
                    SQLLogic.Update("userinfo", $"CreationStage=4", $"UserID={userid}");
                    return 4;

                case "имя":
                    SendMessage($"Введите имя",
                       userid, keyboardbuilder.Build());
                    SQLLogic.Update("userinfo", $"CreationStage=5", $"UserID={userid}");
                    return 5;

                case "готово":
                    Menus.Menu();
                    SendMessage($"\nЯ обновил информацию, {nickname}.\nА теперь можем отправиться покорять эту галактику.",
                    userid, keyboardbuilder.Build());

                    SQLLogic.Update("userinfo", $"GameReady=0", $"UserID={userid}");
                    SQLLogic.Update("userinfo", $"CreationStage=3", $"UserID={userid}");

                    return 0;
            }
        }

        public static int ChangeNickname(long? userid, string message)
        {
            nickname = message;
            SQLLogic.Update("userinfo", $"Nickname={message}", $"UserID={userid}");
            SQLLogic.Update("userinfo", $"CreationStage=3", $"UserID={userid}");
            return 3;
        }

        public static int ChangeGender(long? userid, string message)
        {
            switch (message)
            {
                default:

                    return 5;

                case "М":
                    gender = 0;
                    break;

                case "Ж":
                    gender = 1;
                    break;
            }
            SQLLogic.Update("userinfo", $"CreationStage=3", $"UserID={userid}");
            SQLLogic.Update("userinfo", $"Gender={gender}", $"UserID={userid}");
            return 3;
        }
    }
}
