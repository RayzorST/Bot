using VKBot.Functions;
using VKBot.Utilities;

namespace VKBot
{
    class Program
    {
        static void Main()
        {
            VKLogic.InitializationToken();
            BotLogic.BotMain();
        }
    }
}