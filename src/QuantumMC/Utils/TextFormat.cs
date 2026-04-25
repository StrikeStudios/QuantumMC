namespace QuantumMC.Utils
{
    public static class TextFormat
    {
        public const char Escape = '§';

        public const string Black = "§0";
        public const string DarkBlue = "§1";
        public const string DarkGreen = "§2";
        public const string DarkAqua = "§3";
        public const string DarkRed = "§4";
        public const string DarkPurple = "§5";
        public const string Gold = "§6";
        public const string Gray = "§7";
        public const string DarkGray = "§8";
        public const string Blue = "§9";
        public const string Green = "§a";
        public const string Aqua = "§b";
        public const string Red = "§c";
        public const string LightPurple = "§d";
        public const string Yellow = "§e";
        public const string White = "§f";
        public const string MinecoinGold = "§g";

        public const string Obfuscated = "§k";
        public const string Bold = "§l";
        public const string Italic = "§o";
        public const string Reset = "§r";

        public static string Clean(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            
            var result = new System.Text.StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == Escape)
                {
                    i++;
                    continue;
                }
                result.Append(text[i]);
            }
            return result.ToString();
        }
        
        public static string Colorize(string text)
        {
            return text.Replace('&', Escape);
        }
    }
}
