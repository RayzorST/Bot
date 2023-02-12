using VKBot.Functions;
using VKBot.Utilities;

namespace VKBot.Models
{
    public class Menus
    {
        public static void Menu()
        {
            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton("Навигация", "навигация", null);
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

        public static void Menu_Navigation()
        {
            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton("Гиперпрыжок", "гиперпрыжок", null);
            VKLogic.keyboardbuilder.AddButton("Сектор", "сектор", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_Hyperleap(long? userid)
        {
            SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
            string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
            string[] Sectors = (Convert.ToString(SQLLogic.command.ExecuteScalar())).Split("/");

            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton(Sectors[0], Sectors[0], null);
            VKLogic.keyboardbuilder.AddButton(Sectors[1], Sectors[1], null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton(Sectors[2], Sectors[2], null);
            VKLogic.keyboardbuilder.AddButton(Sectors[3], Sectors[3], null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton(Sectors[4], Sectors[4], null);
            VKLogic.keyboardbuilder.AddButton(Sectors[5], Sectors[5], null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }
    }
}
