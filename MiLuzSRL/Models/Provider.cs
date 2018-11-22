using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiLuzSRL.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Currency { get; set; }
        public bool HasDebt { get; set; }
    }
}