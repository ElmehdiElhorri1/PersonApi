using System;
using System.Collections.Generic;

namespace PersonApi.Data.Models
{
    public partial class Person
    {
        public Person()
        {
            Donation = new HashSet<Donation>();
            PersonAddress = new HashSet<PersonAddress>();
            PersonContact = new HashSet<PersonContact>();
        }

        public int PersonKey { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<Donation> Donation { get; set; }
        public virtual ICollection<PersonAddress> PersonAddress { get; set; }
        public virtual ICollection<PersonContact> PersonContact { get; set; }
    }
}
