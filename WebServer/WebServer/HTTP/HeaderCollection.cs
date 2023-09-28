using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.HTTP
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers = new Dictionary<string, Header>();

        public int Count => this.headers.Count;

        public void Add(string name, string value)
        {
            Header header = new Header(name, value);
            this.headers.Add(name, header);
        }

    }
}
