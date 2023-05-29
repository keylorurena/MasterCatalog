using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCatalog.Models
{
    public class Response
    {
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public bool Status { get; set; }
        public object Result { get; set; }

        public Response(string message, string internalMessage, bool status)
        {
            Message = message;
            InternalMessage = internalMessage;
            Status = status;
        }

        public Response(string message, bool status, object result)
        {
            Message = message;
            Status = status;
            Result = result;
        }

        public Response(object result, bool status = true)
        {
            Status = status;
            Result = result;
        }
    }
}