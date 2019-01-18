using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        
        public IEnumerable<MembershipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}