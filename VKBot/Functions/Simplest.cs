using VKBot.Utilities;

namespace VKBot.Functions
{
    internal class Simplest
    {
        public static void SendMoney(long? from, string to, string value)
        {
            SQLLogic.Search(true, "Credits", "userinfo", "UserID", Convert.ToString(from));
            int count = Convert.ToInt32(SQLLogic.command.ExecuteScalar());
            try
            {
                if (VKLogic.CheckUser(from))
                {
                    if (count >= Convert.ToInt32(value))
                    {
                        SQLLogic.Update("userinfo", "Credits=Credits-" + value, "GameID=" + Convert.ToString(from));
                        SQLLogic.Update("userinfo", "Credits=Credits+" + value, "GameID=" + to);
                    }
                    else
                    {
                        BotLogic.Menu();
                        VKLogic.SendMessage("Не хватает денег", from, VKLogic.keyboardbuilder.Build());
                    }
                }
                else
                {
                    BotLogic.Menu();
                    VKLogic.SendMessage("Пользователь не найден", from, VKLogic.keyboardbuilder.Build());
                }
            }
            catch
            {
                BotLogic.Menu();
                VKLogic.SendMessage("Ошибка ввода", from, VKLogic.keyboardbuilder.Build());
            }
                
        }

        public static void SendMesseng(string from, string to, int text)
        {
            try
            {
                //if(VKLogic.CheckUser(to))
            }
            catch
            {

            }
        }
    }
}
