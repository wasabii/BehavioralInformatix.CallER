using System;
using System.Diagnostics.Contracts;
using System.Net;

namespace BehavioralInformatix.CallER.Client
{

    /// <summary>
    /// Describes a CallER error response.
    /// </summary>
    public class CallERErrorException :
        Exception
    {

        readonly HttpStatusCode statusCode;
        readonly CallERError error;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="error"></param>
        public CallERErrorException(HttpStatusCode statusCode, CallERError error)
            : base(error?.Message)
        {
            this.statusCode = statusCode;
            this.error = error;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="error"></param>
        /// <param name="innerException"></param>
        public CallERErrorException(HttpStatusCode statusCode,CallERError error, Exception innerException)
            : base(error?.Message, innerException)
        {
            this.statusCode = statusCode;
            this.error = error;
        }

        /// <summary>
        /// Gets the HTTP status code from the response.
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get { return statusCode; }
        }

        /// <summary>
        /// Gets the error description object.
        /// </summary>
        public CallERError Error
        {
            get { return error; }
        }

    }

}
