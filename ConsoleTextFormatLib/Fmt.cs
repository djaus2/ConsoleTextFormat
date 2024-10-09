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
        // public const string fgblack = "\u001b[30m";
        // public const string bgblack = "\u001b[40m";

        private const int fgblack = 30;
        private const int bgblack = 40;
        private const int bfgblack = 60;
        private const int bbgblack = 70;

        /// <summary>
        /// Foreground/Background Format colors
        /// </summary>
        public enum Clr { black = 0, red, green, yellow, blue, magenta, cyan, white };

        /// <summary>
        /// Set foreground color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static string fg(Clr clr) { return $"\u001b[{fgblack + (int)clr}m"; }
        /// <summary>
        /// Set background color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static string bg(Clr clr) { return $"\u001b[{bgblack + (int)clr}m"; }
        /// <summary>
        /// Set bold foreground color
        /// </summary>
        /// <param name="clr">Color</param>
        /// <returns></returns>
        public static string bfg(Clr clr) { return $"\u001b[{bfgblack + (int)clr}m"; }
        /// <summary>
        /// Set bold background color
        /// </summary>
        /// <param name="clr">Color</param>
        /// <returns></returns>
        public static string bbg(Clr clr) { return $"\u001b[{bbgblack + (int)clr}m"; }
    }
}
