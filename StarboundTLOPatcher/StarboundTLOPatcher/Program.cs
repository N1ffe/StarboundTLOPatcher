namespace StarboundTLOPatcher
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length >= 2)
            {
                await TLOPatcher.Run(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("Program requires 2 parameters:" +
                    "\n1 - Full path to the target mod object folder, i.e. \"C:\\ModName\\objects\"" +
                    "\n2 - Full path to your mod folder, i.e. \"C:\\YourMod\"");
                Console.WriteLine("Example: StarboundTLOPatcher.exe \"C:\\ModName\\objects\" \"C:\\YourMod\"");
            }
        }
    }
}