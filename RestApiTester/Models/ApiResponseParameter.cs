using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class ApiResponseParameter
    {
        public ApiResponseParameter(RequestParameter p)
        {
            this.Request = p;
        }
        public RequestParameter Request
        {
            get;
        }
        public HttpStatusCode HttpStatus
        {
            get;
            set;
        }
        public string S3Text
        {
            get;
            set;
        }
        public Type Type
        {
            get;
            set;
        }
        public string RawContent
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
    }
}
