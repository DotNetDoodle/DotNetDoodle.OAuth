using System.Net.Http;
using System.Net.Http.Headers;

namespace DotNetDoodle.OAuth.Core
{
    public static class HttpRequestMessageExtensions
    {
        public static void SetBearerToken(this HttpRequestMessage request, string token)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
