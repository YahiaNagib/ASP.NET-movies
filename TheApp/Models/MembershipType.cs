using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheApp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public int SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
    }
}