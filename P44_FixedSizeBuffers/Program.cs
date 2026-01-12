using System;
unsafe struct Buffer
{
    public fixed int values[5];
}
class Program
{
    unsafe static void Main()
    {
        Buffer b = new Buffer();
        for(int i=0;i<5;i++) b.values[i]=i*i;
        for(int i=0;i<5;i++) Console.WriteLine(b.values[i]);
    }
}
