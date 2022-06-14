using Grpc.Core;
using Greet;

namespace client
{
    class Program
    {
        const string Target = "127.0.0.1:50051";

        static void Main(string [] args)
        {
            Channel channel = new Channel(Target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Client connected successfully");
            });

            var client = new GreetingService.GreetingServiceClient(channel);

            DoSimpleGreet(client);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }

        public static void DoSimpleGreet(GreetingService.GreetingServiceClient client)
        {
            var greeting = new Greeting()
            {
                FirstName = "Diego",
                LastName = "Canizales"
            };

            var request = new GreetingRequest() { Greeting = greeting };
            var response = client.Greet(request);

            Console.WriteLine(response.Result);
        }
    }
}
