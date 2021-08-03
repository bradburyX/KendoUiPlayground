using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KendoUiPlayground.Repository.Model
{
    public enum Gender
    {
        Male,
        Female,
        Genderfluid,
        Unknown
    }
    public class Customer
    {
        public Guid Id { get; set; }
        public Gender Gender { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; } 
    }
}
