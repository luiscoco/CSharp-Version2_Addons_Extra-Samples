using System;
class Box<T>
{
    private T value = default(T);
    public T Value { get { return value; } set { this.value = value; } }
}
class Program
{
    static void Main()
    {
        Box<int> bi = new Box<int>();
        Console.WriteLine("Default int = " + bi.Value);
        Box<string> bs = new Box<string>();
        Console.WriteLine("Default string = " + (bs.Value==null?"null":bs.Value));
    }
}
