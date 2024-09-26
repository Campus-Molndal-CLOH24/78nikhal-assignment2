namespace CLO24_SecondTurnInNiklasH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We call the initializer class to run the factory methods
            VehicleInitializer.RunFactory();
        }

        internal static void FactoryShutdown()
        {
            // Take a key input to exit the program, it is a bit more user friendly than just closing the console window
            Console.WriteLine("Press play on tape (press any key)");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}