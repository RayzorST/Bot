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
            VKLogic.keyboardbuilder.AddButton("Назад", "назад", VkNet.Enums.SafetyEnums.KeyboardButtonColor.Primary);
        }

        public static void Menu_Maneuver(long? userid)
        {
            SQLLogic.Search(true, "Sector", "userinfo", $"UserID={userid.ToString()}");
            string Sector = Convert.ToString(SQLLogic.command.ExecuteScalar());

            SQLLogic.Search(true, "SectorsNames", "sectors", $"SectorName='{Sector}'");
            string[] Sectors = Convert.ToString(SQLLogic.command.ExecuteScalar()).Split("/");

            VKLogic.keyboardbuilder.Clear();
            VKLogic.keyboardbuilder.AddButton(Sectors[0], Sectors[0] + " 0", SpaceTravel.SectorStatus(Sectors[0]));
            VKLogic.keyboardbuilder.AddButton(Sectors[1], Sectors[1] + " 1", SpaceTravel.SectorStatus(Sectors[1]));
            VKLogic.keyboardbuilder.AddButton(Sectors[2], Sectors[2] + " 2", SpaceTravel.SectorStatus(Sectors[2]));
            VKLogic.keyboardbuilder.AddLine();
            VKLogic.keyboardbuilder.AddButton(Sectors[4], Sectors[4] + " 4", SpaceTravel.SectorStatus(Sectors[4]));
            VKLogic.keyboardbuilder.AddButton(Sectors[3], Sectors[3] + " 3", SpaceTravel.SectorStatus(Sectors[3]));
            VKLogic.keyboardbuilder.AddButton(Sectors[5], Sectors[5] + " 5", SpaceTravel.SectorStatus(Sectors[5]));
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
