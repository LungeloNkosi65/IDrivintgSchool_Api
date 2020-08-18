using System;
using System.Collections.Generic;

namespace DrivingSchool_Api
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string IdNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string CellphoneNumber { get; set; }
        public string Address { get; set; }
    }
}
