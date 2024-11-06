# ConsoleTextFormat

## Summary

A simple static class library facilitating 
.NET Console app text formatting in ```Console.Write()``` 
and ```Console.WriteLine()``` statements without explicitly using escape codes.

## Links

- Nuget Package: [ConsoleTextFormat](https://www.nuget.org/packages/ConsoleTextFormat)
- [Detailed blog post](https://davidjones.sportronics.com.au/coding/ConsoleTextFormat-Formatting_Console_App_Text-coding.html)
- [Console Virtual Terminal Sequences: MS Learn Ref](https://learn.microsoft.com/en-us/windows/console/console-virtual-terminal-sequences?wt.mc_id=WDIT-MVP-5000301)

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
            Fmt.Press2con();
            Fmt.Press2con("when ready."); 
       }
    }
}
```

[Image of running app](https://davidjones.sportronics.com.au/media/consoleformat.png)  
**_Console app output_**

## Updates

- 2024-09-07: Added ```Fmt.Heading()``` and ```Fmt.RainbowHeading()``` methods to format text as headings.
- 2024-09-07: Added ```Fmt.Info(topic,info)``` method.
- 2024-09-13: Added ```Press2Con``` "Press any key to continue" method. Optional messages to pre and post pend. Also, Info() 2nd parameter IS optional.
- 2024-09-13: Added ```Prompt()``` added. As per Info() but no newline. Heading clears screen. And '_' in heading to blank.
- 2024-11-06: Added  HideMenu Items to Layout. So items on end of enum list can not appear in menu.
```cs
    Layout.AddHideMenuItems("MaxType");
    Layout.AddHideMenuItems("Undefined");
    Testtype = Layout.SelectEnum<ConsoleTestType>((int)Testtype + 1, ref quit, true);
    Layout.ClearHideMenuItems();
```


