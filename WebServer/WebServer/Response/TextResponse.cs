using WebServer.HTTP;

namespace WebServer.Response;

public class TextResponse : ContentResponse
{
    public TextResponse(string text) : base(text, ContentType.PlainText)
    {
    }
}