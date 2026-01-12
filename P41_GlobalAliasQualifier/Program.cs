using System;
namespace System { class Console { public static void WriteLine(string s){ System.Console.WriteLine("Custom: "+s); } } }
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello from custom Console");
        global::System.Console.WriteLine("Hello from real System.Console");
    }
}
