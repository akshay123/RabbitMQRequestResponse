using System;
using EasyNetQ;
using Messages;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Stopwatch sw = new Stopwatch();

            using (var bus = RabbitHutch.CreateBus("host=localhost;timeout=60")) 
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");

                while ((input = Console.ReadLine()) != "Quit")
                {

                    var request = new RequestMessage(input);

                    sw.Start();
                    var response = await bus.RequestAsync<RequestMessage, RespondMessage>(request);
                    sw.Stop();

                    lock (Console.Out)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Got message: {response.Text} in {sw.ElapsedMilliseconds} ms.");
                        Console.ResetColor();
                    }
                    sw.Reset();
                }
            }
        }
    }
}
