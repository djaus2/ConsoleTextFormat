namespace ConsoleApp9
{
    using System;
    using ConsoleTextFormat;
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"{Fmt.bg(Fmt.Clr.white)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Clr.yellow)}Hello, {Fmt.b}World!{Fmt._b}{Fmt.clear}");
            Console.WriteLine($"{Fmt.fg(Fmt.Clr.blue)}Hello, {Fmt.clear}World!");
        }
    }
}
