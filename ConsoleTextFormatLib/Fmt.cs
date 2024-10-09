namespace ConsoleTextFormat
{
    /// <summary>
    /// Format a Console app's text
    /// <para>i.e. In Console.Write/ln()</para>
    /// <para>Bold, Underline, Foreground/Background Colors</para>
    /// <code>eg Console.WriteLine($"{Fmt.fg(Fmt.Clr.yellow)}Hello, {Fmt.b}World!{Fmt._b}");</code>
    /// <para>Hello in yellow text, World in bold yellow</para>
    /// </summary>
    public static class Fmt 
    {
        /// <summary>
        /// Clear the console
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }
        /// <summary>
        /// Reset all formatting
        /// </summary>
        public static void Reset()
        {
            Console.ResetColor();
        }

        //////////////////////////////////////////////////////////////

        /// <summary>
        /// Clear all formatting
        /// </summary>
        public const string clear = "\u001b[0m";
        /// <summary>
        /// Bold
        /// </summary>
        public const string b = "\u001b[1m";
        /// <summary>
        /// Not Bold
        /// </summary>
        public const string _b = "\u001b[22m";
        /// <summary>
        /// Underline
        /// </summary>
        public const string ul = "\u001b[4m";
        /// <summary>
        /// Not Underline
        /// </summary>
        public const string _ul = "\u001b[24m";
        /// <summary>
        /// [Negative] Swap foreground and background colors
        /// </summary>
        public const string n = "\u001b[7m";
        /// <summary>
        /// [Positive] Foreground/Background to normal
        /// </summary>
        public const string _n = "\u001b[27m";

        //////////////////////////////////////////////////////////////

        private const int ifgblack = 30;
        private const int ibgblack = ifgblack + 10;
        private const int ibfgblack = ifgblack + 30;
        private const int ibbgblack = ibfgblack + 10;

        /// <summary>
        /// Foreground colors
        /// </summary>
        public static string fgBla  = $"\u001b[{ifgblack + (int)Clr.black}m";
        public static string fgRed  = $"\u001b[{ifgblack + (int)Clr.red}m";
        public static string fgGre  = $"\u001b[{ifgblack + (int)Clr.green}m";
        public static string fgYel  = $"\u001b[{ifgblack + (int)Clr.yellow}m";
        public static string fgblu  = $"\u001b[{ifgblack + (int)Clr.blue}m";
        public static string fgMag  = $"\u001b[{ifgblack + (int)Clr.magenta}m";
        public static string fgCya  = $"\u001b[{ifgblack + (int)Clr.cyan}m";
        public static string fgWhi  = $"\u001b[{ifgblack + (int)Clr.white}m";

        /// <summary>
        /// Background colors
        /// </summary>
        public static string bgBla = $"\u001b[{ibgblack + (int)Clr.black}m";
        public static string bgRed = $"\u001b[{ibgblack + (int)Clr.red}m";
        public static string bgGre = $"\u001b[{ibgblack + (int)Clr.green}m";
        public static string bgYel = $"\u001b[{ibgblack + (int)Clr.yellow}m";
        public static string bgblu = $"\u001b[{ibgblack + (int)Clr.blue}m";
        public static string bgMag = $"\u001b[{ibgblack + (int)Clr.magenta}m";
        public static string bgCya = $"\u001b[{ibgblack + (int)Clr.cyan}m";
        public static string bgWhi = $"\u001b[{ibgblack + (int)Clr.white}m";

        /// <summary>
        /// Bold Foreground colors
        /// </summary>
        public static string bfgBla = $"\u001b[{ibfgblack + (int)Clr.black}m";
        public static string bfgRed = $"\u001b[{ibfgblack + (int)Clr.red}m";
        public static string bfgGre = $"\u001b[{ibfgblack + (int)Clr.green}m";
        public static string bfgYel = $"\u001b[{ibfgblack + (int)Clr.yellow}m";
        public static string bfgblu = $"\u001b[{ibfgblack + (int)Clr.blue}m";
        public static string bfgMag = $"\u001b[{ibfgblack + (int)Clr.magenta}m";
        public static string bfgCya = $"\u001b[{ibfgblack + (int)Clr.cyan}m";
        public static string bfgWhi = $"\u001b[{ibfgblack + (int)Clr.white}m";

        /// <summary>
        /// Bold Background colors
        /// </summary>
        public static string bbgBla = $"\u001b[{ibbgblack + (int)Clr.black}m";
        public static string bbgRed = $"\u001b[{ibbgblack + (int)Clr.red}m";
        public static string bbgGre = $"\u001b[{ibbgblack + (int)Clr.green}m";
        public static string bbgYel = $"\u001b[{ibbgblack + (int)Clr.yellow}m";
        public static string bbgblu = $"\u001b[{ibbgblack + (int)Clr.blue}m";
        public static string bbgMag = $"\u001b[{ibbgblack + (int)Clr.magenta}m";
        public static string bbgCya = $"\u001b[{ibbgblack + (int)Clr.cyan}m";
        public static string bbgWhi = $"\u001b[{ibbgblack + (int)Clr.white}m";

        //////////////////////////////////////////////////////////////


        /// <summary>
        /// Foreground/Background Format colors
        /// </summary>
        public enum Clr { black = 0, red, green, yellow, blue, magenta, cyan, white };

        /// <summary>
        /// Set foreground color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static string fg(Clr clr) { return $"\u001b[{ifgblack + (int)clr}m"; }
        /// <summary>
        /// Set background color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static string bg(Clr clr) { return $"\u001b[{ibgblack + (int)clr}m"; }
        /// <summary>
        /// Set bold foreground color
        /// </summary>
        /// <param name="clr">Color</param>
        /// <returns></returns>
        public static string bfg(Clr clr) { return $"\u001b[{ibfgblack + (int)clr}m"; }
        /// <summary>
        /// Set bold background color
        /// </summary>
        /// <param name="clr">Color</param>
        /// <returns></returns>
        public static string bbg(Clr clr) { return $"\u001b[{ibbgblack + (int)clr}m"; }
    }
}
