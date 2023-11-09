using WebServer.Common;
using WebServer.HTTP;

namespace WebServer.Response;

public class ContentResponse : Responce
{
    public ContentResponse(string content, string contentType) : base(StatusCode.OK)
    {
        Guard.AgainstNull(content);
        Guard.AgainstNull(contentType);
        
        this.Headers.Add(Header.ContentType, contentType);
        this.Body = content;
    }
}