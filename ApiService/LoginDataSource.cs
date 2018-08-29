using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIntegration.Models;

namespace ApiIntegration
{

    public class LoginDataSource
    {
        public List<LoginDto> Users { get; set; }
        public static LoginDataSource Account { get; }= new LoginDataSource();

        public LoginDataSource()
        {
            Users = new List<LoginDto>()
            {
                new LoginDto()
                {
                    Id = 1,
                    Name = "Name",
                    Password = "Password",
                    EmailAddress = "email@address.com",
                    Premium = true

                },
                new LoginDto()
                {
                    Id = 2,
                    Name = "Name2",
                    Password = "Password2",
                    EmailAddress = "email@address.com",
                    Premium = true

                }
            };

        }
    }
}
