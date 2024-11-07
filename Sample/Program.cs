using B = ConsoleTextFormat.Fmt.Bold;
using F = ConsoleTextFormat.Fmt;
namespace ConsoleApp9
{
    using System;
    using ConsoleTextFormat;

    internal class Program
    {

        enum Animals { fox,cat,dog,zebra,lion,tiger, rat, bird, butterfly,fish, stingray,snake }
        static void Main(string[] args)
        {

            
            Layout.Heading("Hello, World!",Fmt.Col.yellow, Fmt.Col.blue);
            Layout.RainbowHeading("Hello, World!", Fmt.Col.yellow);
            Layout.Info("This is a topic:", "Information");
            Console.WriteLine($"{Fmt.bg(Fmt.Col.white)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Col.yellow)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Col.blue)}Hello, {Fmt.clear}World!");
            Console.WriteLine($"{B.fgRed}{B.bgCya}Hello, {Fmt.clear}World!");
            Console.WriteLine($"{F.fgRed}{F.bgCya}Hello, {Fmt.clear}World!");

            var lst = Layout.GenerateEnumMenuList<Animals>();
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
            char ch = Layout.Prompt4Ch("Hello Joe", '2', new List<char> { '1', '2' });
            Console.WriteLine($"{ch} selected");
            int menuResp = Layout.Prompt4Num(2, 4, true);
            if (menuResp < 0)
                return; //Quit
            menuResp = Layout.Prompt4Num(2, 12, true);
            if (menuResp < 0)
                return; //Quit
            bool quit = false;
            //fish is hidden so won't show in next menu.
            Layout.AddHideMenuItems("fish");
            Animals vv = Layout.SelectEnum<Animals>(2, ref quit, true);
            if (quit)
                return;
            Console.WriteLine($"Selected: {vv}");
            Layout.Press2Continue();
            Layout.Press2Continue("Wait for completion");
            Layout.Press2Continue("","when ready.");
            Layout.Press2Continue("Wait for completion", "when ready.");
            var col = ConColors.SelevctaConsoleColor();
            var rgb = ConColors.GetRGBfromConsoleColor(col);
            Console.WriteLine($"{rgb.Item1},{rgb.Item2},{rgb.Item3}");
        }
    }
}
