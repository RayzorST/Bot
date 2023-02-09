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
                }
                else
                    VKLogic.SendMessage("Пользователь не найден", from, null);
            }
            catch
            {
                VKLogic.SendMessage("Ошибка ввода", from, null);
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
