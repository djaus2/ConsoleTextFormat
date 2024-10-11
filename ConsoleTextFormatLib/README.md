# ConsoleTextFormat

## Summary

A simple static class library facilitating 
.NET Console app text formatting in ```Console.Write()``` 
and ```Console.WriteLine()``` statements without explicitly using escape codes.

## Link
[Console Virtual Terminal Sequences: MS Learn Ref](https://learn.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences?wt.mc_id=WDIT-MVP-5000301)

## About
Whilst there are same Console class methods for setting text and background colors, there are no methods for setting text attributes such as bold, underline, etc. This library provides a simple way to do this.
This library enables inline code _(that is, with in a string)_ to change  text format when
writing to the console using ```Console.Write() and Console.WriteLine()``` methods. 

The class entities have been made a cryptic as possible whilst maintaining interpretation upon inspection.
The strings so used are not escaped, but are interpreted by the library. 

**String Interpolation** is used to embed the format strings in the text to be written to the console.

The format strings are at 2 levels.
  - Quite explicit e.g. ```{Fmt.fg(Fmt.Col.yellow)}```
  - Cryptic e.g. ```{F.fgYel}```

Both of the code segments above will produce the same result. 
The cryptic version requires the using statements as in the following code to alias the class names.

```cs

## Example Console Code

```cs
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
        }
    }
}
```
[Image of running app](https://github.com/djaus2/ConsoleTextFormat/blob/master/consoleformat.png?raw=true)  
**_Console app output_**

## Updates

- 2021-09-07: Added ```Fmt.Heading()``` and ```Fmt.RainbowHeading()``` methods to format text as headings.
- 2021-09-07: Added ```Fmt.Info(topic,info)``` added.