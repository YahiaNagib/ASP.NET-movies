using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheApp.Models;

namespace TheApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}