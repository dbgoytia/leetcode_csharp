﻿using Grpc.Core;
using Greet;

namespace server
{
    class Program
    {
        const int Port = 50051;

        static void Main(string [] args)
        {
            Server? server = null;

            try
            {
                server = new Server()
                {
                    Services = { GreetingService.BindService(new GreetingServiceImpl()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };
                server.Start();
                Console.WriteLine("The server is listening on : " + Port);
                Console.ReadKey(); 
            }
            catch(IOException e)
            {
                Console.WriteLine("The server failed to start: " + e.Message);
                throw;
            }
            finally
            {
                if (server != null)
                {
                    server.ShutdownAsync().Wait();
                }
            }
        }
    }
}