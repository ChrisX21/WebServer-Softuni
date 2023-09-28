using System.Net;
using System.Net.Sockets;

namespace WebServer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
          HttpServer server = new HttpServer("127.0.0.1", 8080);

          server.Start();
            Console.ReadLine();
        }
    }
}