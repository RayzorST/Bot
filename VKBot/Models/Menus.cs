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
            VKLogic.keyboardbuilder.AddButton("Удалить аккаунт", "удалить", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Negative);
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
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
            VKLogic.keyboardbuilder.AddButton("Сектор", "сектор", null);
            VKLogic.keyboardbuilder.AddButton("Манёвр", "манёвр", null);
            VKLogic.keyboardbuilder.AddButton("Гиперпрыжок", "гиперпрыжок", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Захватить", "захватить", null);
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_Maneuver(long? userid)
        {
            SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
            string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
            string[] Sectors = Convert.ToString(SQLLogic.command.ExecuteScalar()).Split("/");

            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton(Sectors[0], Sectors[0] + " 0", VKBeauty.SectorStatus(Sectors[0], "Noname", "---"));
            VKLogic.keyboardbuilder.AddButton(Sectors[1], Sectors[1] + " 1", VKBeauty.SectorStatus(Sectors[1], "Noname", "---"));
            VKLogic.keyboardbuilder.AddButton(Sectors[2], Sectors[2] + " 2", VKBeauty.SectorStatus(Sectors[2], "Noname", "---"));
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton(Sectors[7], Sectors[7] + " 7", VKBeauty.SectorStatus(Sectors[7], "Noname", "---"));
            VKLogic.keyboardbuilder.AddButton("Направления", "Направления", null);
            VKLogic.keyboardbuilder.AddButton(Sectors[3], Sectors[3] + " 3", VKBeauty.SectorStatus(Sectors[3], "Noname", "---"));
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton(Sectors[6], Sectors[6] + " 6", VKBeauty.SectorStatus(Sectors[6], "Noname", "---"));
            VKLogic.keyboardbuilder.AddButton(Sectors[5], Sectors[5] + " 5", VKBeauty.SectorStatus(Sectors[5], "Noname", "---"));
            VKLogic.keyboardbuilder.AddButton(Sectors[4], Sectors[4] + " 4", VKBeauty.SectorStatus(Sectors[4], "Noname", "---"));
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_Hyperleap()
        {
            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_NewSector()
        {
            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }
    }
}
