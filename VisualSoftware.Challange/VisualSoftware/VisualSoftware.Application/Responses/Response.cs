using System;
using System.Collections.Generic;
using System.Text;

namespace VisualSoftware.Application.Responses
{
    public class Response<T>
    {
        public Response(){}
        public Response(T response)
        {
            Data = response;
        }

        public T Data { get; set; }
    }
}
