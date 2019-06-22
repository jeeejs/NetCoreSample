using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonMicroservice.Models
{
    public class PersonAuth : Person
    {
        public bool Authenticated { get; set; }
        public string Error { get; set; }
    }
}
