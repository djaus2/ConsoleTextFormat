using B = ConsoleTextFormat.Fmt.Bold;
namespace ConsoleApp9
{
    using System;
    using ConsoleTextFormat;

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"{Fmt.bg(Fmt.Col.white)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Col.yellow)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Col.blue)}Hello, {Fmt.clear}World!");
            Console.WriteLine($"{B.fgRed}{B.bgCya}Hello, {Fmt.clear}World!");
        }
    }
}
