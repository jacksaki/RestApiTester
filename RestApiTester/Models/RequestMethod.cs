using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public enum RequestMethod
    {
        [EnumText("GET")]
        Get,
        [EnumText("POST")]
        Post,
    }
}
