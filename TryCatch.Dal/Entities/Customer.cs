﻿using System.ComponentModel.DataAnnotations;

namespace TryCatch.Dal.Entities
{
    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
    }
}
