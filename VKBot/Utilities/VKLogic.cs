using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Enums.Filters;
using VkNet.Model.Keyboard;

namespace VKBot.Utilities
{
    public class VKLogic
    {
        public static KeyboardBuilder keyboardbuilder = new KeyboardBuilder();
        public static VkApi vkApi = new VkApi();

        public static void InitializationToken()
        {
            try
            {
                vkApi.Authorize(new ApiAuthParams
                {
                    AccessToken = Resources.ResourceManager.GetString("GroupToken")
                });
                Console.WriteLine($"[log] [{DateTime.Now}] Token is valid");
            }
            catch
            {
                Console.WriteLine($"[log] [{DateTime.Now}] Token is not valid");

            }

            try
            {
                SQLLogic.InitializationServer();
                Console.WriteLine($"[log] [{DateTime.Now}] Server started");
            }
            catch
            {
                Console.WriteLine($"[log] [{DateTime.Now}] Server Error ");
            }
        }

        public static bool CheckUser(long? userid)
        {
            if (SQLLogic.SearchCount("userinfo", "UserID", userid.ToString()) == 0)
                return false;
            else
                return true;
        }

        public static bool CheckBan(long? userid)
        {
            if (CheckUser(userid) == true)
                return false;
            else
            {
                SQLLogic.Search(true, "isBaned", "userinfo", "UserID", userid.ToString());

                if (Convert.ToInt32(SQLLogic.command.ExecuteScalar()) == 0)
                    return true;
                else
                    return false;
            }
        }

        public static void SendMessage(string message, long? userid, MessageKeyboard Keybord)
        {
            try
            {
                vkApi.Messages.Send(new MessagesSendParams
                {
                    Message = message,
                    UserId = userid,
                    RandomId = new Random().Next(),
                    Keyboard = Keybord
                });
                Console.WriteLine($"[log] [{DateTime.Now}] Message was sent to {userid}");
            }
            catch
            {
                Console.WriteLine($"[log] [{DateTime.Now}] Message was not sent to {userid}");
            }
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
            Console.WriteLine($"[log]Message was sent from {userid}");

        }
    }
}
