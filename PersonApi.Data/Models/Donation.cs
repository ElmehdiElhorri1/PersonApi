using System;
using System.Collections.Generic;

namespace PersonApi.Data.Models
{
    public partial class Donation
    {
        public int DonationKey { get; set; }
        public DateTime? DonationDate { get; set; }
        public int? DonationAmount { get; set; }
        public int? PersonKey { get; set; }
        public string EmployeeKey { get; set; }

        public virtual Person PersonKeyNavigation { get; set; }
    }
}
