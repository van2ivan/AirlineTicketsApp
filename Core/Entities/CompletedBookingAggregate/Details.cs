using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.CompletedBookingAggregate
{
    public class Details 
    {
        public Details()
        {
            
        }
        public Details(string firstName, string lastName, string passport, string citizenship)
        {
            FirstName = firstName;
            LastName = lastName;
            Passport = passport;
            Citizenship = citizenship;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
        public string Citizenship { get; set; }
    }
}