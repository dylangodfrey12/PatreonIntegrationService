using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiIntegration.Models
{
    public class UserProfileDto
    {
        public enum Address { Street, Zipcode, City, State} 

        public long UserProfileId { get; set; }
        public byte ProfileImage { get; set; }
        public byte BackgroundImage { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }

        public string Street { get; set; }

        public int Zipcode { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public int LoginId { get; set; }
        public LoginDto LoginDto { get; set; }

    }
}
