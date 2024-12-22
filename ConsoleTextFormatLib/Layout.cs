using static ConsoleTextFormat.Fmt;

namespace ConsoleTextFormat
{
    public class Selection
    {
        public Selection(int index)
        {
            Index = index;
            Item = "";
        }
        public Selection(int index, List<string> items)
        {
            Index = index;
            Item = items[index];
        }

        public int Index { get; set; }
        public string Item { get; set; }
    }
    public static class Layout
    {
        /// <summary>
        /// Present a CSV list of items and prompt for selection
        /// </summary>
        /// <param name="defaultInt">Default item index</param>
        /// <param name="csvList">CSV list of items</param>
        /// <param name="quit">Quit can be an option, returns Index = -1</param>
        /// <param name="back">Back can be an option, returns index = -2</param>
        /// <param name="promptcol"></param>
        /// <param name="infocol"></param>
        /// <returns>Selection(Index,Item)</returns>
        public static Selection PromptWithCSVList(int defaultInt, string csvList, bool quit = true, bool back = true, Col promptcol = Col.blue, Col infocol = Col.yellow)
        {
            // Can have colon precedinging info
            // CSV list of items is on end
            string[] partsArr = csvList.Split(":");
            List<string> items = (partsArr[partsArr.Length - 1].Split(",")).ToList<string>();
            int selection = DisplayMenu(defaultInt + 1, items, quit, back);//, promptcol ,  infocol);
            if (selection < 0)
                return new Selection(selection);
            else if (selection >= items.Count)
            {
                // This shouldn't happen
                return new Selection(-3);
            }
            else
                return new Selection(selection, items);
        }

        /// <summary>
        /// Present a CSV list of items and prompt for selection
        /// </summary>
        /// <param name="defaultInt">Default item index</param>
        /// <param name="csvList">CSV list of items</param>
        /// <param name="quit">Quit can be an option, returns Index = -1</param>
        /// <param name="back">Back can be an option, returns index = -2</param>
        /// <param name="promptcol"></param>
        /// <param name="infocol"></param>
        /// <returns>Selection(Index,Item)</returns>
        public static Selection PromptWithDictionaryList(int defaultInt, Dictionary<int, string> dList, bool quit = true, bool back = true, Col promptcol = Col.blue, Col infocol = Col.yellow)
        {
            // Can have colon precedinging info
            // CSV list of items is on end

            List<string> items = dList.Values.ToList<string>();
            int selection = DisplayMenu(defaultInt + 1, items, quit, back);//, promptcol ,  infocol);
            if (selection < 0)
                return new Selection(selection);
            else if (selection >= items.Count)
            {
                // This shouldn't happen
                return new Selection(-3);
            }
            else
                return GetNthKey(dList,selection);
        }
        /// <summary>
        /// Find the nth key-value pair in a dictionary and return its key
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static Selection GetNthKey(Dictionary<int, string> dList, int n)
        {
            if (n < 0 || n >= dList.Count)
                return new Selection(-1); 

                var enumerator = dList.GetEnumerator();
                for (int i = 0; i <= n; i++)
                    enumerator.MoveNext();

            return new Selection(enumerator.Current.Key);
        }
        



        /// <summary>
        /// Write heading in text color with background color with space btw each letter
        /// </summary>
        /// <param name="heading">Heading</param>
        /// <param name="col">Text Color </param>
        /// <param name="backcol">Background Color</param>
        public static void Heading(string heading, Col col = Col.white, Col backcol = Col.black)
        {
            heading = heading.Replace("_", " ");
            Reset();
            Console.Clear();
            int c = (int)backcol;
            while (col == (Col)c)
            {
                c++;
                if (c >= 8)
                    c = 0;
            }
            backcol = (Col)c;
            Console.Write($"{bg(backcol)}");//Background
            for (int i = 0; i < heading.Length; i++)
            {
                if (heading[i] == ' ')
                    Console.Write("  ");
                else
                {
                    Console.Write($"{fg(col)}{heading[i]}");
                    if (Char.IsAscii(heading[i]))
                        Console.Write(" ");
                }
;
            }
            Console.WriteLine();
            Reset();
        }

        /// <summary>
        /// Write heading in rainbow colors with space between each letter
        /// </summary>
        /// <param name="heading">Heading</param>
        /// <param name="backcol">Background color</param>
        public static void RainbowHeading(string heading, Col backcol = Col.black)
        {
            heading = heading.Replace("_", " ");
            Reset();
            Console.Clear();
            int c = -1;
            Console.Write($"{bg(backcol)}");//Background
            for (int i = 0; i < heading.Length; i++)
            {
                if (heading[i] == ' ')
                    Console.Write("  ");
                else
                {
                    do
                    {
                        c++;
                        if (c >= 8)
                            c = 0;
                    }
                    while (backcol == (Col)c);
                    Console.Write($"{fg((Col)c)}{heading[i]}");
                    if (Char.IsAscii(heading[i]))
                        Console.Write(" ");
                }
            }
            Console.WriteLine();
            Reset();
        }

        /// <summary>
        /// Write a topic heading and information in different colors
        ///  ... on same line
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="info"></param>
        /// <param name="topiccol"></param>
        /// <param name="infocol"></param>
        public static void Info(string topic, string info = "", Col topiccol = Col.blue, Col infocol = Col.yellow)
        {
            Prompt(topic, info, topiccol, infocol);
            Console.WriteLine();
            Reset();
        }

        /// <summary>
        /// As per Info but without line feed
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="info"></param>
        /// <param name="topiccol"></param>
        /// <param name="infocol"></param>
        public static void Prompt(string topic, string info = "", Col topiccol = Col.blue, Col infocol = Col.yellow)
        {
            Reset();
            Console.Write($"{fg(topiccol)}{topic} ");

            // Make sure colors are different
            int c = (int)infocol;
            while (topiccol == (Col)c)
            {
                c++;
                if (c >= 8)
                    c = 0;
            }
            infocol = (Col)c;
            Console.Write($"{fg(infocol)}{info}");
            Reset();
        }

        /// <summary>
        /// Display "Press any key to continue" prompt, and wait for key press
        /// </summary>
        /// <param name="preMsg">Additional msg added at start of prompt</param>
        /// <param name="postMsg">Additional msg that can be appended</param>
        /// <param name="backcol">Background color. (Fg is bold white)</param>
        public static void Press2Continue(string preMsg = "", string postMsg = "", Col backcol = Col.green)
        {
            string fs = ". ";
            if (preMsg == "") fs = "";
            Console.Write($"{bgGre}{Bold.fgWhi}{b}{preMsg}{fs}Press any key to continue {postMsg}{clr}");
            Console.ReadKey();
            Console.WriteLine();
        }

        private static List<string> MenuItemsToHide = new List<string>();

        public static void AddHideMenuItems(string item)
        {
            MenuItemsToHide.Add(item.ToLower().Replace("_", " "));
        }
        public static void ClearHideMenuItems()
        {
            MenuItemsToHide = new List<string>();
        }

        /// <summary>
        /// Generate a List<tring></tring> of menu items from an enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>List</returns>
        public static List<string> GenerateEnumMenuList<T>()
        {
            var values = Enum.GetValues(typeof(T));
            List<string> list = new List<string>();
            if (values != null)
            {

               //var Values = values.
                foreach (var menuItem in values)
                {
                    if (menuItem != null)
                    {
                        var msg = $"{menuItem}".Replace("_", " ");
                        if (MenuItemsToHide.Contains(msg.ToLower()))
                            continue;
                        if (!string.IsNullOrEmpty(msg))
                        {
                            list.Add(msg);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Display menu of enum items and prompt for selection.
        /// Optional Quit option
        /// Note selection is by single key press 1,2,3,4,5,6,7,8,9,A,B,C etc.
        ///    ... As displayed in menu
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="def">index of default value</param>
        /// <param name="Quit">Returned true of Q pressed</param>
        /// <param name="quit">Optionally provided. If true can select Q</param>
        /// <returns></returns>
        public static T SelectEnum<T>(int def, ref bool Quit, bool quit = false)
        {
            Quit = false;
            List<string> list = GenerateEnumMenuList<T>();
           
            int index =  DisplayMenu(def, list, quit);
            if (index < 0)
            {
                Quit = true;
                return default(T);
            }
            T t = (T)Enum.ToObject(typeof(T), index);
            return t;
        }

        /// <summary>
        /// Display menu from supplied list and prompt for selection.
        /// Optional Quit option
        /// Note selection is by single key press 1,2,3,4,5,6,7,8,9,A,B,C etc.
        ///    ... As displayed in menu
        /// </summary>
        /// <param name="list">List of string of menu optionse</param
        /// <param name="def">index of default value</param>
        /// <param name="quit">Optionally provided. If true can select Q</param>
        /// <returns>Selection, or -1 for Quit</returns>
        public static int DisplayMenu(int def, List<string> list, bool quit = false, bool back=false)
        {
            for (int i = 1; i <= list.Count(); i++)
            {
                char ch = '\0';
                if (i < 10)
                {
                    ch = (char)('0' + i);
                }
                else
                {
                    ch = (char)('A' + i - 10);
                }
                Console.WriteLine($"{ch}.\t{list[i - 1]}");
            }
            var val = Prompt4Num(def, list.Count(), quit, back);
            return val;
        }

        public static List<char> GenerateListofKeys(int maxSelection)
        {
            List<char> selectFrom = new List<char>();
            for (int ii = 1; ii <= maxSelection; ii++)
            {
                if (ii < 10)
                {
                    selectFrom.Add((char)('0' + ii));
                }
                else
                {
                    selectFrom.Add((char)('A' + ii - 10));
                }
            };
            return selectFrom;
        }

        /// <summary>
        /// Prompt for a menu int selection
        /// Generates list of 1 ... maxSelection
        /// For >9 , uses A, B, C, ... etc
        /// </summary>
        /// <param name="defaultInt">Default selection</param>
        /// <param name="maxSelection">DisplayMenu from 1 ... maxSelection</param>
        /// <param name="Quit">Optional [Q] option</param>
        /// <param name="promptcol">Prompt color</param>
        /// <param name="infocol">Selection color</param>
        /// <returns></returns>
        public static int Prompt4Num(int defaultInt, int maxSelection, bool Quit=false, bool Back=false, Col promptcol = Col.blue, Col infocol = Col.yellow)
        {
            List<char> selectFrom = GenerateListofKeys(maxSelection);

            string prompt = $"DisplayMenu from 1 ... {selectFrom.Last()}";
            if (Quit)
            {
                selectFrom.Add('Q');
                prompt += " or Q to quit";
            }
            if (Back)
            {
                selectFrom.Add((char)ConsoleKey.LeftArrow); //% is (char)ConsoleKey.LeftArrow
                prompt += " or <- to go back";
            }

            char ch = Prompt4Ch(prompt, (char)('0' + defaultInt), selectFrom, promptcol, infocol);
            if ((ch >= 'A') && (ch != 'Q') && (ch != (char)ConsoleKey.LeftArrow))
                ch = (char)(ch - 'A' + 10 + '0');
           
            return ch switch
            {
                ((char)ConsoleKey.LeftArrow) => -2,
                'Q' => -1,
                _ => ch - 48 - 1,
            };
        }

        
        /// <summary>
        /// Prompt for a single character from a list of characters
        /// Enter return supplied default
        /// Backspaces over invalid entries.
        /// Nb1: Characters are case insensitive
        /// Nb2: Response is on key press, no [Enter] required.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="defaultKey"></param>
        /// <param name="selectFrom"></param>
        /// <param name="promptcol"></param>
        /// <param name="infocol"></param>
        /// <returns></returns>
        public static char Prompt4Ch(string prompt, char defaultKey, List<char> selectFrom, Col promptcol = Col.blue, Col infocol = Col.yellow)
        {
            Reset();
            Console.Write($"{fg(promptcol)}{prompt}: ");

            // Make sure colors are different
            int c = (int)infocol;
            while (promptcol == (Col)c)
            {
                c++;
                if (c >= 8)
                    c = 0;
            }
            infocol = (Col)c;
            char tempKey = defaultKey;
            do
            {

                Console.Write($"{fg(infocol)}{defaultKey}");
                Console.Write($"\b");
                var keyCode = Console.ReadKey();
                if (keyCode.Key == ConsoleKey.Enter)
                    break;// Use default
                else if (keyCode.Key == ConsoleKey.LeftArrow)
                    tempKey = (char)ConsoleKey.LeftArrow; //ie '%'
                else
                {
                    tempKey = keyCode.KeyChar;
                }
                tempKey = char.ToUpper(tempKey);
                Console.Write($"\b");
                Console.Write($"{delete}");
            } while (!selectFrom.Contains(tempKey));
            defaultKey = tempKey;
            Reset();
            Console.WriteLine();
            return defaultKey;
        }

    }
}
