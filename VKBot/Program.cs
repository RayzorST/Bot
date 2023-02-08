using VKBot.Utilities;

namespace VKBot
{
    class Program
    {
        static void Main()
        {
            VKLogic.InitializationToken();

            if (VKLogic.CheckBan() == false)
                BotLogic.BotMain();
        }
    }
}