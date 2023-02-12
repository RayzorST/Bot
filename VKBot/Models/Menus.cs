using VKBot.Utilities;

namespace VKBot.Models
{
    public class Menus
    {
        public static void Menu()
        {
            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton("Сектор", "сектор", null);
            VKLogic.keyboardbuilder.AddButton("Перелет", "перелет", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Взаимоотношения", "взаимоотношения", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Насторйки", "настройки", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_Settings()
        {
            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton("Сменить ник", "сменить ник", null);
            VKLogic.keyboardbuilder.AddButton("Сменить пол", "сменить пол", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
            VKLogic.keyboardbuilder.AddButton("Удалить аккаунт", "удалить", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Negative);
        }

        public static void Menu_Social()
        {
            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton("Передать кредиты", "передать кредиты", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_SpaceTravel()
        {
            VKLogic.keyboardbuilder.Clear();
        }
    }
}
