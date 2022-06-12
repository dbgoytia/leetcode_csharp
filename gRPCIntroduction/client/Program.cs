using Grpc.Core;
using Dummy;

namespace client
{
    class Program
    {
        const string Target = "127.0.0.1:5051";

        static void Main(string [] args)
        {
            Channel channel = new Channel(Target, ChannelCredentials.Insecure);

            channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Client connected successfully");
            });

            var client = new DummyService.DummyServiceClient(channel);

            channel.ShutdownAsync().Wait();
            Console.ReadKey();
        }
    }
}
