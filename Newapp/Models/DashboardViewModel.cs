using System.Collections.Generic;

namespace Newapp.Models
{
    public class DashboardViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Lead> Leads { get; set; }
    }
}
