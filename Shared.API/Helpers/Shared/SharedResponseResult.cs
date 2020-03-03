using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Shared.API.Helpers.Shared
{
    /// <summary>
    /// Custom Response Result 
    /// </summary>
    public class SharedResponseResult<T> : ObjectResult
    {
        /// <summary>
        /// SharedResponseResult constructor
        /// </summary>
        /// <param name="result">Object to be returned when the request succeeded</param>
        /// <param name="statusCode">200 for success, 400 for validation Errors, 500 for Server Errors, 401 UnAuthenticated, 403 for UnAuthorized</param>
        /// <param name="notify">flag to indicate weather this messages should be shown as notifications or not</param>
        /// <param name="messages">validation error messages or server error messages or custom success messages</param>
        public SharedResponseResult(T result, HttpStatusCode statusCode = HttpStatusCode.OK, bool notify = false, params string[] messages) 
            : base(new SharedResponse<T>(result, (int)statusCode, notify, messages))
        {
            StatusCode = (int)statusCode;
        }

        /// <summary>
        /// SharedResponseResult constructor
        /// </summary>
        /// <param name="result">Object to be returned when the request succeeded</param>
        /// <param name="totalRows"></param>
        /// <param name="statusCode">200 for success, 400 for validation Errors, 500 for Server Errors, 401 UnAuthenticated, 403 for UnAuthorized</param>
        /// <param name="notify">flag to indicate weather this messages should be shown as notifications or not</param>
        /// <param name="messages">validation error messages or server error messages or custom success messages</param>
        public SharedResponseResult(T result, int totalRows, HttpStatusCode statusCode = HttpStatusCode.OK, bool notify = false, params string[] messages)
            : base(new SharedResponse<T>(result, totalRows, (int)statusCode, notify, messages))
        {
            StatusCode = (int)statusCode;
        }

        /// <summary>
        /// SharedResponseResult constructor StatusCode = OK, Notify = false
        /// </summary>
        /// <param name="result">Object to be returned when the request succeeded</param>
        /// <param name="messages">validation error messages or server error messages or custom success messages</param>
        public SharedResponseResult(T result, params string[] messages) : this(result, HttpStatusCode.OK, false, messages) { }

        /// <summary>
        /// SharedResponseResult constructor Notify = false
        /// </summary>
        /// <param name="result">Object to be returned when the request succeeded</param>
        /// <param name="statusCode">200 for success, 400 for validation Errors, 500 for Server Errors, 401 UnAuthenticated, 403 for UnAuthorized</param>
        /// <param name="messages">validation error messages or server error messages or custom success messages</param>
        public SharedResponseResult(T result, HttpStatusCode statusCode = HttpStatusCode.OK, params string[] messages) : this(result, statusCode, false, messages) { }

        /// <summary>
        /// SharedResponseResult constructor StatusCode = OK
        /// </summary>
        /// <param name="result">Object to be returned when the request succeeded</param>
        /// <param name="notify">flag to indicate weather this messages should be shown as notifications or not</param>
        /// <param name="messages">validation error messages or server error messages or custom success messages</param>
        public SharedResponseResult(T result, bool notify = false, params string[] messages) : this(result, HttpStatusCode.OK, notify, messages) { }
    }

    /// <summary>
    /// Custom Response Class 
    /// </summary>
    public class SharedResponse<T>
    {
        /// <summary>
        ///  ResponseResult constructor
        /// </summary>
        /// <param name="result">Object to be returned when the request succeeded</param>
        /// <param name="statusCode">200 for success, 400 for validation Errors, 500 for Server Errors, 401 UnAuthenticated, 403 for UnAuthorized</param>
        /// <param name="notify">flag to indicate weather this messages should be shown as notifications or not</param>
        /// <param name="messages">validation error messages or server error messages or custom success messages</param>
        public SharedResponse(T result, int statusCode = (int)HttpStatusCode.OK, bool notify = false, string[] messages = null)
        {
            Result = result;
            StatusCode = statusCode;
            Messages = messages;
            Notify = notify;
        }
        public SharedResponse(T result,
            int totalRows,
            int statusCode = (int)HttpStatusCode.OK,
            bool notify = false,
            string[] messages = null)
        {
            Result = result;
            StatusCode = statusCode;
            Messages = messages;
            Notify = notify;
            TotalRows = totalRows;
        }
        public int StatusCode { get; set; }
        public string[] Messages { get; set; }
        public T Result { get; set; }
        public bool Notify { get; set; }
        public int TotalRows { get; set; }
    }
}
