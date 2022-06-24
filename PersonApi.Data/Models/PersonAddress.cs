using System;
using System.Collections.Generic;

namespace PersonApi.Data.Models
{
    public partial class PersonAddress
    {
        public int PersonAddressKey { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }
        public int? PersonKey { get; set; }

        public virtual Person PersonKeyNavigation { get; set; }
    }
}
