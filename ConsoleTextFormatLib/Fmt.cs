using System.Drawing;
using static ConsoleTextFormat.Fmt;

namespace ConsoleTextFormat
{
    /// <summary>
    /// Format a Console app's text
    /// <para>i.e. In Console.Write/ln()</para>
    /// <para>Bold, Underline, Foreground/Background Colors</para>
    /// <code>eg Console.WriteLine($"{Fmt.fg(Fmt.Col.yellow)}Hello, {Fmt.b}World!{Fmt._b}");</code>
    /// <para>Hello in yellow text, World in bold yellow</para>
    /// For Colored Bold use the following declaration to shorten the code
    /// <code>using B = ConsoleTextFormat.Fmt.Bold;</code>
    /// <code>$"{B.fgRed}"</code> is the same as <code>$"{Fmt.Bold.fgRed}"</code>
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
        //ESC [ 3 ~
        public const string delete = "\u001b[3~";

        /// <summary>
        /// Cursor Back one
        /// ESC [ <n> D
        /// </summary>
        public const string cursorBack = "\u001b[1D";
        /// <summary>
        /// Clear all formatting
        /// </summary>
        public const string clear = "\u001b[0m";
        /// <summary>
        /// (Alt) Clear all formatting
        /// </summary>
        public const string clr = "\u001b[0m";
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
        private const int ibfgblack = 90;
        private const int ibbgblack = ibfgblack + 10;


        /// <summary>
        /// Foreground Black
        /// <code>${Fmt.fgBla}Hello{Fmt.Col}</code>
        /// </summary>    
        public static string fgBla = $"\u001b[{ifgblack + (int)Col.black}m";
        /// <summary>
        /// Foreground Red
        /// <code>${Fmt.fgRed}Hello{Fmt.Col}</code>
        /// </summary
        public static string fgRed = $"\u001b[{ifgblack + (int)Col.red}m";
        /// <summary>
        /// Foreground Green
        /// <code>${Fmt.fgGre}Hello{Fmt.Col}</code
        /// </summary
        public static string fgGre = $"\u001b[{ifgblack + (int)Col.green}m";
        /// <summary>
        /// Foreground Yellow
        /// <code>${Fmt.fgYel}Hello{Fmt.Col}</code
        /// </summary
        public static string fgYel = $"\u001b[{ifgblack + (int)Col.yellow}m";
        /// <summary>
        /// Foreground Blue
        /// <code>${Fmt.fgBlu}Hello{Fmt.Col}</code
        /// </summary
        public static string fgblu = $"\u001b[{ifgblack + (int)Col.blue}m";
        /// <summary>
        /// Foreground Magent
        /// <code>${Fmt.fgMag}Hello{Fmt.Col}</code
        /// </summary
        public static string fgMag = $"\u001b[{ifgblack + (int)Col.magenta}m";
        /// <summary>
        /// Foreground Cyan
        /// <code>${Fmt.fgCya}Hello{Fmt.Col}</code
        /// </summary
        public static string fgCya = $"\u001b[{ifgblack + (int)Col.cyan}m";
        /// <summary>
        /// Foreground White
        /// <code>${Fmt.fgWhi}Hello{Fmt.Col}</code
        /// </summary
        public static string fgWhi = $"\u001b[{ifgblack + (int)Col.white}m";


        /// <summary>
        /// Background colors
        /// <code>${Fmt.bgWhi}Hello{Fmt.Col}</code
        /// </summary>
        public static string bgBla = $"\u001b[{ibgblack + (int)Col.black}m";
        public static string bgRed = $"\u001b[{ibgblack + (int)Col.red}m";
        public static string bgGre = $"\u001b[{ibgblack + (int)Col.green}m";
        public static string bgYel = $"\u001b[{ibgblack + (int)Col.yellow}m";
        public static string bgBlu = $"\u001b[{ibgblack + (int)Col.blue}m";
        public static string bgMag = $"\u001b[{ibgblack + (int)Col.magenta}m";
        public static string bgCya = $"\u001b[{ibgblack + (int)Col.cyan}m";
        public static string bgWhi = $"\u001b[{ibgblack + (int)Col.white}m";
        

        /// <summary>
        /// Bold fg/bg colors
        /// <code>${Fmt.Bold.fgRed}Hello{Fmt.Col}</code>
        /// </summary>
        public static class Bold
        {

            /// <summary>
            /// Bold Foreground colors
            /// </summary>
            public static string fgBla = $"\u001b[{ibfgblack + (int)Col.black}m";
            public static string fgRed = $"\u001b[{ibfgblack + (int)Col.red}m";
            public static string fgGre = $"\u001b[{ibfgblack + (int)Col.green}m";
            public static string fgYel = $"\u001b[{ibfgblack + (int)Col.yellow}m";
            public static string fgblu = $"\u001b[{ibfgblack + (int)Col.blue}m";
            public static string fgMag = $"\u001b[{ibfgblack + (int)Col.magenta}m";
            public static string fgCya = $"\u001b[{ibfgblack + (int)Col.cyan}m";
            public static string fgWhi = $"\u001b[{ibfgblack + (int)Col.white}m";

            /// <summary>
            /// Bold Background colors
            /// </summary>
            public static string bgBla = $"\u001b[{ibbgblack + (int)Col.black}m";
            public static string bgRed = $"\u001b[{ibbgblack + (int)Col.red}m";
            public static string bgGre = $"\u001b[{ibbgblack + (int)Col.green}m";
            public static string bgYel = $"\u001b[{ibbgblack + (int)Col.yellow}m";
            public static string bgblu = $"\u001b[{ibbgblack + (int)Col.blue}m";
            public static string bgMag = $"\u001b[{ibbgblack + (int)Col.magenta}m";
            public static string bgCya = $"\u001b[{ibbgblack + (int)Col.cyan}m";
            public static string bgWhi = $"\u001b[{ibbgblack + (int)Col.white}m";
        }


        //////////////////////////////////////////////////////////////


        /// <summary>
        /// Foreground/Background Format colors
        /// </summary>
        public enum Col { black = 0, red, green, yellow, blue, magenta, cyan, white };

        /// <summary>
        /// Set foreground color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static string fg(Col clr) { return $"\u001b[{ifgblack + (int)clr}m"; }
        /// <summary>
        /// Set background color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static string bg(Col clr) { return $"\u001b[{ibgblack + (int)clr}m"; }
        /// <summary>
        /// Set bold foreground color
        /// </summary>
        /// <param name="clr">Color</param>
        /// <returns></returns>
        public static string Bfg(Col clr) { return $"\u001b[{ibfgblack + (int)clr}m"; }
        /// <summary>
        /// Set bold background color
        /// </summary>
        /// <param name="clr">Color</param>
        /// <returns></returns>
        public static string Bbg(Col clr) { return $"\u001b[{ibbgblack + (int)clr}m"; }


    }
}
