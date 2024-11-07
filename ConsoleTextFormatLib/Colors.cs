using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTextFormat
{
    public static class ConColors
    {
        /// <summary>
        /// Menu to select a ConsoleColor
        /// </summary>
        /// <returns></returns>
        public static ConsoleColor SelevctaConsoleColor()
        {
            bool quit = false;
            Console.WriteLine("Select color: ");
            // ConsoleColor
            ConsoleColor col = Layout.SelectEnum<ConsoleColor>(1, ref quit, false);
            return col;
        }

        /// <summary>
        /// Menu to elect a ConsoleColor and return the RGB values
        /// </summary>
        /// <returns></returns>
        public static Tuple<byte, byte, byte> SelectRGB()
        {
            var col = SelevctaConsoleColor();
            var rgb = GetRGBfromConsoleColor(col);
            return rgb;
        }

        /// <summary>
        /// Get RGB values from a ConsoleColor
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public static Tuple<byte, byte, byte> GetRGBfromConsoleColor(ConsoleColor col)
        {
            Color color = Color.FromName($"{col}");
            Tuple<byte, byte, byte> rgb = new Tuple<byte, byte, byte>(color.R, color.G, color.B);
            return rgb;
        }

        /// <summary>
        /// Get a ConsoleColor from RGB values          
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ConsoleColor GetConsoleColorFromRGB(byte r, byte g, byte b)
        {
            Color color = Color.FromArgb(r, g, b);
            ConsoleColor col = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Name);
            return col;
        }

    }
}
