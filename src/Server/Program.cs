using System;
using System.Threading.Tasks;
using EasyNetQ;
using Messages;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServeNow();

        }

        private static void ServeNow()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            var bus = RabbitHutch.CreateBus("host=localhost");

            var responder = bus.RespondAsync<RequestMessage, RespondMessage>(request =>
            {
                RespondMessage output = GetData(request);
                return Task.FromResult (output);
            });




            //bus.Respond<RequestMessage, RespondMessage>(request =>
            //{
            //    var output = new RespondMessage($"{request.Text} all done!");
            //    Console.WriteLine($"Got: {request.Text}");
            //    return output;
            //}
                 
            //);


            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine();

            bus.Dispose();
        }

        private static RespondMessage GetData(RequestMessage request)
        {
            var output = new RespondMessage($"{request.Text} all done!");
            Console.WriteLine($"Got: {request.Text}");
            return output;
        }
    }
}
