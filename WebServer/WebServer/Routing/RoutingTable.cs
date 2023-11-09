using WebServer.Common;
using WebServer.HTTP;
using WebServer.Response;

namespace WebServer.Routing;

public class RoutingTable : IRoutingTable
{
    private readonly Dictionary<Method, Dictionary<string, Responce>> routes;

    public RoutingTable() => this.routes = new()
    {
        [Method.GET] = new(),
        [Method.POST] = new(),
        [Method.PUT] = new(),
        [Method.DELETE] = new()
    };

    public IRoutingTable Map(string url, Method method, Responce response) => method switch
    {
        Method.GET => this.MapGet(url, response),
        Method.POST => this.MapPost(url, response),
        _ => throw new InvalidOperationException($"Method {method} is not supported.")
    };

    public IRoutingTable MapGet(string url, Responce response)
    {
        Guard.AgainstNull(url, nameof(url));
        Guard.AgainstNull(response, nameof(response));

        this.routes[Method.GET][url] = response;
        return this;
    }

    public IRoutingTable MapPost(string url, Responce response)
    {
        Guard.AgainstNull(url, nameof(url));
        Guard.AgainstNull(response, nameof(response));

        this.routes[Method.POST][url] = response;
        return this;
    }

    public Responce MathRequest(Request request)
    {
        var requestMethod = request.Method;
        var requestUrl = request.Url;

        if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestUrl))
        {
            return new NotFoundResponse();
        }

        return this.routes[requestMethod][requestUrl];
    }
}