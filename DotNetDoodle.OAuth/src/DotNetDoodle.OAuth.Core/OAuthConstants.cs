
namespace DotNetDoodle.OAuth.Core
{
    public static class OAuth
    {
        public static class GrantTypes
        {
            public const string AuthorizationCode = "authorization_code";
            public const string ClientCredentials = "client_credentials";
            public const string RefreshToken = "refresh_token";
            public const string Password = "password";
        }

        public static class ResponseTypes
        {
            public const string Code = "code";
            public const string Token = "token";
        }

        public static class Errors
        {
            public const string InvalidRequest = "invalid_request";
            public const string InvalidClient = "invalid_client";
            public const string InvalidGrant = "invalid_grant";
            public const string UnsupportedResponseType = "unsupported_response_type";
            public const string UnsupportedGrantType = "unsupported_grant_type";
            public const string UnauthorizedClient = "unauthorized_client";
        }

        public static class Extra
        {
            public const string ClientId = "client_id";
            public const string RedirectUri = "redirect_uri";
        }

        public static class RequestParams
        {
            public class ResourceOwner
            {
                public const string GrantType = "grant_type";
                public const string Username = "username";
                public const string Password = "password";
                public const string Scope = "scope";
            }
        }

        public static class ResponseParams
        {
            public class AccessToken
            {
                public const string Token = "access_token";
                public const string TokenType = "token_type";
                public const string ExpiresIn = "expires_in";
                public const string RefreshToken = "refresh_token";
            }
        }
    }
}