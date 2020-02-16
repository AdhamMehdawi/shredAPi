using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shared.API.Helpers.Shared
{
    public class ShredValidationException : Exception
    {
        public string[] Messages;
        public bool Notify;
        public ShredValidationException(params string[] message)
        {
            Messages = message;
            Notify = false;
        }
        public ShredValidationException(bool notify = false, params string[] message)
        {
            Messages = message;
            Notify = notify;
        }
        public ShredValidationException(ModelStateDictionary modelState, bool notify = false) : this(notify, modelState.Values.SelectMany(mse => mse.Errors.Select(err => err.ErrorMessage)).ToArray())
        {
        }
    }

    public class ShredBadRequestException : Exception
    {
        public string[] Messages;
        public bool Notify;
        public ShredBadRequestException(params string[] message)
        {
            Messages = message;
            Notify = false;
        }
        public ShredBadRequestException(bool notify = false, params string[] message)
        {
            Messages = message;
            Notify = notify;
        }
        public ShredBadRequestException(ModelStateDictionary ModelState, bool notify = false) : this(notify, ModelState.Values.SelectMany(mse => mse.Errors.Select(err => err.ErrorMessage)).ToArray())
        {
        }
    }
}
