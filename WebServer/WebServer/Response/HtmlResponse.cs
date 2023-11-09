using WebServer.HTTP;

namespace WebServer.Response;

public class HtmlResponse : ContentResponse
{
    public HtmlResponse(string text) : base(text, ContentType.Html)
    {
        
    }
}