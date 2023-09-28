using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.HTTP
{
    public class Header
    {
        public Header(string headerName, string headervalue)
        {
            this.Name = headerName;
            this.Value = headervalue;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
