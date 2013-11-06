using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetDoodle.OAuth.Core
{
    public class OAuthBearerHandler : DelegatingHandler
    {
        public OAuthBearerHandler()
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // TODO: 1-) Check to see if we have an available bearer token to send with this request.
            //           1.1-) if we have, send it through the Authorization: Bearer {token} and jump to 3.
            //           1.2-) if not, continue with 2.
            //       2-) As we don't have a bearer token available, prepare for the Token request. Not sure for know which flow should we apply here.
            //           2-1-) After getting the token from the server, add it to its known place with the refresh token if available.

            return base.SendAsync(request, cancellationToken);
        }
    }
}