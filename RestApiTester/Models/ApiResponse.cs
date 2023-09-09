using Livet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class ApiResponse
    {
        public static ApiResponse Create(ApiResponseParameter p)
        {
            var res = new ApiResponse(p);
            if(p.Type != null)
            {
                res.Result = JsonConvert.DeserializeObject(p.RawContent, p.Type);
            }
            res.BuildValueText();
            return res;
        }
        private void BuildValueText()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine(this.Parameter.Request.GetUrl());
            sb.AppendLine();
            sb.AppendLine($"HTTP Status: {(int)this.Parameter.HttpStatus} {this.Parameter.HttpStatus}");

            if (this.Parameter.Type != null)
            {
                foreach (var p in this.Parameter.Type.GetProperties().Where(x => x.PropertyType.IsValueType || x.PropertyType == typeof(string)))
                {
                    sb.AppendLine($"{p.Name} :{p.GetValue(this.Result)}");
                }
            }
            this.ValueText = sb.ToString();
        }
        private ApiResponse(ApiResponseParameter p)
        {
            this.Parameter = p;
        }

        public string ValueText
        {
            get;
            private set;
        }

        private ApiResponseParameter Parameter
        {
            get;
        }
        public double ElapsedSeconds
        {
            get
            {
                return (this.EndDate - this.StartDate).TotalMilliseconds / 1000d;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return this.Parameter.StartDate;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return this.Parameter.EndDate;
            }
        }
        public object Result
        {
            get;
            private set;
        }
        public string RawContent
        {
            get
            {
                return this.Parameter.RawContent;
            }
        }
    }
}
