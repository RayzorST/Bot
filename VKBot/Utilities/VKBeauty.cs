namespace VKBot.Utilities
{
    internal class VKBeauty
    {
        public static VkNet.Enums.SafetyEnums.KeyboardButtonColor SectorStatus(
            string name,
            string Default,
            string Negativ)
        {
            if (name == Default)
                return VkNet.Enums.SafetyEnums.KeyboardButtonColor.Default;
            else if (name == Negativ)
                return VkNet.Enums.SafetyEnums.KeyboardButtonColor.Negative;
            else
                return VkNet.Enums.SafetyEnums.KeyboardButtonColor.Positive;
        }
    }
}
