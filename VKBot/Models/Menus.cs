using VKBot.Utilities;

namespace VKBot.Models
{
    public class Menus
    {
        public static void Menu()
        {
            VKLogic.keyboardbuilder.AddButton("Сектор", "сектор", null);
            VKLogic.keyboardbuilder.AddButton("Перелет", "перелет", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Перевести", "перевести", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Насторйки", "настройки", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_Settings()
        {
            VKLogic.keyboardbuilder.AddButton("Удалить аккаунт", "удалить", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_SpaceTravel()
        {

        }
    }
}
