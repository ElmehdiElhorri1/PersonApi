using System;
using System.Collections.Generic;
using System.Text;

namespace PersonApi.Module.Module
{
    public class PersonAddressModel
    {
        public int PersonAddressKey { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }
        public int? PersonKey { get; set; }
    }
}
