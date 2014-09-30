using System;

namespace server
{
    class Program
    {
        static void Main()
        {
            Network.Start();

            while (true)
            {
                Console.ReadKey(true);
            }
        }
    }
}
