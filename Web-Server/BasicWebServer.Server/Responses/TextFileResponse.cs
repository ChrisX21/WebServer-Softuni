using System.IO;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses;

public class TextFileResponse : Response
{
    private string FileName { get; init; }

    public TextFileResponse(string FileName) : base(HTTP.StatusCode.OK)
    {
        this.FileName = FileName;
        
        this.Headers.Add(Header.ContentType, ContentType.PlainText);
    }

    public override string ToString()
    {
        if (File.Exists(this.FileName))
        {
            this.Body = File.ReadAllTextAsync(this.FileName).Result;
            var fileBytesCount = new FileInfo(this.FileName).Length;
            this.Headers.Add(Header.ContentLength, fileBytesCount.ToString());
            this.Headers.Add(Header.ContentDisposition, $"attachment; filename=\"{this.FileName}\"");
        }
        return base.ToString();
    }
}