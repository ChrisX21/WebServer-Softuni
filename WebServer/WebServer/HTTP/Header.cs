using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Common;

namespace WebServer.HTTP
{
    public class Header
    {

        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";
        public Header(string headerName, string headervalue)
        {
            Guard.AgainstNull(headerName, nameof(headerName));
            Guard.AgainstNull(headervalue, nameof(headervalue));
            this.Name = headerName;
            this.Value = headervalue;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
