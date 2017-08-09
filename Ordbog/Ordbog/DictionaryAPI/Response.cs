using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Ordbog.Models
{
    public class Response<T>
    {
        public string Error { get; set; }
        public int StatusCode { get; set; }
        public T Result { get; set; }
    }
}
