using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;
using VkNet.Model.Keyboard;
using VKBot.Utilities;

namespace VKBot.Utilities
{
    public class VKLogic
    {
        public static KeyboardBuilder keyboardbuilder = new KeyboardBuilder();
        public static VkApi vkApi = new VkApi();

        public static void InitializationToken()
        {
            vkApi.Authorize(new ApiAuthParams
            {
                AccessToken = Resources.ResourceManager.GetString("GroupToken")
            });

            try
            {
                SQLLogic.InitializationServer();
                Console.WriteLine("[log]Server started");
            }
            catch
            {
                Console.WriteLine("[log]Server Error");
            }
        }

        public static bool CheckBan()
        {
            object[] messageinfo = GetMessage();
            long? userid = Convert.ToInt32(messageinfo[2]);

            SQLLogic.SearchCount("userinfo", "UserID", userid.ToString());
            int count = Convert.ToInt32(SQLLogic.command.ExecuteScalar());
            if (count == 0)
                return false;
            else
            {
                return true;
            }
        }

        public static void SendMessage(string message, long? userid, MessageKeyboard Keybord)
        {
            vkApi.Messages.Send(new MessagesSendParams
            {
                Message = message,
                UserId = userid,
                RandomId = new Random().Next(),
                Keyboard = Keybord
            });
            Console.WriteLine($"[log]Message send to {userid}");
        }

        public static object[] GetMessage()
        {
            string message = "";
            string keyname = "";
            long? userid = 0;

            var dialogs = vkApi.Messages.GetDialogs(new MessagesDialogsGetParams
            {
                Count = 1,
                Unread = true
            });

            if (dialogs.Messages.Count != 0)
            {
                if (dialogs.Messages[0].Body != null)
                {
                    message = dialogs.Messages[0].Body.ToString();
                }
                else
                {
                    message = "";
                }

                if (dialogs.Messages[0].Payload != null && dialogs.Messages[0].Payload != "")
                {
                    keyname = dialogs.Messages[0].Payload.ToString();
                    keyname = keyname.Split("{\"button\":\"")[1];
                    keyname = keyname.Split("\"}")[0];
                }
                else
                {
                    keyname = "";
                }

                userid = dialogs.Messages[0].UserId.Value;
                vkApi.Messages.MarkAsRead(userid.ToString());
                return new object[] { message, keyname, userid };
            }
            else
                return new object[] { null, null, null };

        }
    }
}
