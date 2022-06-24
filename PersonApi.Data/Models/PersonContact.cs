using System;
using System.Collections.Generic;

namespace PersonApi.Data.Models
{
    public partial class PersonContact
    {
        public int ContactKey { get; set; }
        public string ContactInfo { get; set; }
        public int? PersonKey { get; set; }
        public string ContactTypeKey { get; set; }

        public virtual Person PersonKeyNavigation { get; set; }
    }
}
