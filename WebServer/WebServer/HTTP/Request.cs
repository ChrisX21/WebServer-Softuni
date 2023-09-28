using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.HTTP
{
    public class Request
    {
        public Method Method { get; set; }

        public string Url { get; set; }

        public HeaderCollection Headers { get; set; }

        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            string[] lines = request.Split(Environment.NewLine);

            string[] firstLine = lines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Method method = ParseMethod(firstLine[0]);
            string url = firstLine[1];

            HeaderCollection headers = ParseHeaders(lines.Skip(1));

            string[] bodyLines = lines.Skip(headers.Count + 2).ToArray();

            string body = string.Join(Environment.NewLine, bodyLines);

            return new Request
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headers)
        {
            HeaderCollection headerCollection = new HeaderCollection();

            foreach (string header in headers)
            {
                if (header == string.Empty)
                {
                    break;
                }

                string[] headerParts = header.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid!");
                }

                string headerName = headerParts[0];
                string headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }
            return headerCollection;
        }

        private static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method);
            }
            catch (Exception)
            {

                throw new InvalidOperationException($"Method '{method}' is not supported!");
            }
        }
    }
}
