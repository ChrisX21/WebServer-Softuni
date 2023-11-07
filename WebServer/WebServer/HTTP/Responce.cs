using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.HTTP
{
    public class Responce
    {
        public Responce(StatusCode statusCode) { 
            this.StatusCode = statusCode;

            this.Headers.Add(Header.Server, "My Web Server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");

        }
        public StatusCode StatusCode { get; init; }
        public HeaderCollection Headers { get; } = new HeaderCollection();
        public string Body { get; set; }
    }
}
