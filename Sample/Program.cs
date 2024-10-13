using B = ConsoleTextFormat.Fmt.Bold;
using F = ConsoleTextFormat.Fmt;
namespace ConsoleApp9
{
    using System;
    using ConsoleTextFormat;

    internal class Program
    {
        static void Main(string[] args)
        {
            Fmt.Heading("Hello, World!",Fmt.Col.yellow, Fmt.Col.blue);
            Fmt.RainbowHeading("Hello, World!", Fmt.Col.yellow);
            Fmt.Info("This is a topic:", "Information");
            Console.WriteLine($"{Fmt.bg(Fmt.Col.white)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Col.yellow)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Col.blue)}Hello, {Fmt.clear}World!");
            Console.WriteLine($"{B.fgRed}{B.bgCya}Hello, {Fmt.clear}World!");
            Console.WriteLine($"{F.fgRed}{F.bgCya}Hello, {Fmt.clear}World!");
            Fmt.Press2con();
            Fmt.Press2con("Wait for completion");
            Fmt.Press2con("","when ready.");
            Fmt.Press2con("Wait for completion", "when ready.");
        }
    }
}
