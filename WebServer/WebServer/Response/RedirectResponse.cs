using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Response
{
    using WebServer.HTTP;
    public class RedirectResponse : Responce
    {
        public RedirectResponse(string location) : base(StatusCode.Found)
        { 
            this.Headers.Add(Header.Location, location);
        }
    }
}
