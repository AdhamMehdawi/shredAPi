using System;

namespace Shared.API.Helpers.Shared
{
    public class SharedAuthorizationException : Exception
    {
        public string[] Messages;
        public SharedAuthorizationException(params string[] message) 
        {
            Messages = message;
        }
    }
    public class SharedAuthenticationException : Exception
    {
        public string[] Messages;
        public SharedAuthenticationException(params string[] message)
        {
            Messages = message;
        }
    }
}
