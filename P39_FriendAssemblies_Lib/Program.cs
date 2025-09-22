using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("P39_FriendAssemblies_App")]
namespace FriendLib
{
    internal class Secret
    {
        internal static string GetMessage() { return "Hello from internal!"; }
    }
}
