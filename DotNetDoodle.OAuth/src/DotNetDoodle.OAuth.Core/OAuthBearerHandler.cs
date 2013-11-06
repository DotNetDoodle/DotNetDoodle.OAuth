using DotNetDoodle.OAuth.Core.Models;
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
        // http://stackoverflow.com/questions/17801995/c-sharp-async-await-limit-of-calls-to-async-methods-locking
        private readonly SemaphoreSlim _syncLock = new SemaphoreSlim(1);
        private readonly Func<HttpRequestMessage, Task<AccessTokenResponse>> _accessTokenFunc;
        private AccessTokenResponse _accessTokenToUse;

        public OAuthBearerHandler(Func<HttpRequestMessage, Task<AccessTokenResponse>> accessTokenFunc)
        {
            _accessTokenFunc = accessTokenFunc;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_accessTokenToUse == null || _accessTokenToUse.IsExprired)
            {
                try
                {
                }
                catch
                {
                    throw;
                }
            }

            // TODO: 1-) Check to see if we have an available bearer token to send with this request.
            //           1.1-) if we have, send it through the Authorization: Bearer {token} and jump to 3.
            //           1.2-) if not, continue with 2.
            //       2-) As we don't have a bearer token available, prepare for the Token request. Not sure for know which flow should we apply here.
            //           2-1-) After getting the token from the server, add it to its known place with the refresh token if available.

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<AccessTokenResponse> RetrieveAccessTokenAsync(HttpRequestMessage request)
        {
            try
            {
                // Only 1 thread can access the function or functions that use this lock, 
                // others trying to access - will wait until the first one released.
                await _syncLock.WaitAsync();
                AccessTokenResponse accessToken = await _accessTokenFunc(request);

                return accessToken;
            }
            finally
            {
                _syncLock.Release();
            }
        }
    }
}