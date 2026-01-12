// Demonstration placeholder: extern alias requires multiple assemblies.
// For teaching, this project shows the syntax but won't compile standalone
// unless you add references with aliases in csproj.
// extern alias Lib1;
// extern alias Lib2;
// using Lib1::MyNamespace;
// using Lib2::MyNamespace;
class Program
{
    static void Main()
    {
        System.Console.WriteLine("Extern alias feature demo (see comments).");
    }
}
