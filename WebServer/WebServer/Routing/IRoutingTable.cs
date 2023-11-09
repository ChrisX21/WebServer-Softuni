using WebServer.HTTP;

namespace WebServer.Routing;

public interface IRoutingTable
{
    IRoutingTable Map(string url, Method method, Responce response);
    IRoutingTable MapGet(string url, Responce response);
    IRoutingTable MapPost(string url, Responce response);
    
}