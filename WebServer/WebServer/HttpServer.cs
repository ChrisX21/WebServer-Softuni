using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    internal class HttpServer
    {
        private readonly IPAddress iPAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAddress, int port)
        {
            this.iPAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.serverListener = new TcpListener(this.iPAddress, port);
        }

        public void Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server is listening on port: {port}.");
            Console.WriteLine("Listening for requests...");

            TcpClient connection = serverListener.AcceptTcpClient();

            NetworkStream stream = connection.GetStream();
            WriteResponce(stream, "Hello");

            connection.Close();
        }

        private void WriteResponce(NetworkStream stream, string message)
        {
            int contentLength = Encoding.UTF8.GetByteCount(message);

            string response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8 
Content-Length: {contentLength}

{message}";

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            stream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream stream)
        {
            int bufferLength = 1024;
            byte[] buffer = new byte[bufferLength];

            StringBuilder sb = new StringBuilder();

            do
            {
                var bytesRead = stream.Read(buffer, 0, bufferLength);

                sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (stream.DataAvailable);

            return sb.ToString();
        }
    }
}
