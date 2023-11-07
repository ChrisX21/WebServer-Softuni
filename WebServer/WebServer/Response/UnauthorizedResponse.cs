using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.HTTP;

namespace WebServer.Response
{
    public class UnauthorizedResponse : Responce
    {
        public UnauthorizedResponse() : base(StatusCode.Unauthorized)
        {
        }
    }
}
