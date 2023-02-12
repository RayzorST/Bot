﻿using VKBot.Functions;
using VKBot.Utilities;
using VkNet.Model;

namespace VKBot.Models.MenuFunctions
{
    public class Menu_Settings : VKLogic
    {
        public static void Get(string message, long? userid)
        {
            switch (message.ToLower())
            {
                default:
                    break;

                case "назад":
                    BotLogic.SettingsOn = false;
                    Menus.Menu();
                    SendMessage("Речь не распознана",
                        userid, keyboardbuilder.Build());
                    break;

                case "сменить ник":
                    break;

                case "сменить пол":
                    break;

                case "удалить":
                    break;
            }
        }
    }
}
