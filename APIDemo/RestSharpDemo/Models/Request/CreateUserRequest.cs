using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Models.Request
{
    public class CreateUserRequest
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}
