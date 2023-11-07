using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Response 
 {
    using WebServer.HTTP;
    public class NotFoundResponse : Responce
    {
        public NotFoundResponse() : base(StatusCode.NotFound)
        {

        }

    }
}
