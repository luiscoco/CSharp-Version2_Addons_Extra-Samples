using System;
class Program
{
    static void Main()
    {
#pragma warning disable 0168
        int unused;
#pragma warning restore 0168
        Console.WriteLine("Pragma warning demo completed.");
    }
}
