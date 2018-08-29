using System;
using System.Linq;
using System.Net;
using ApiIntegration.Entities;
using ApiIntegration.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiIntegration.Services
{
    public class SqlLoginData :ILoginData
    {
        private LoginContext _context;

        public SqlLoginData(LoginContext context)
        {
            _context = context;
        }
        public IQueryable<LoginDto> Get(int id)
        {
           
           throw new NotImplementedException();
        }

        public LoginDto GetUser(LoginDto login)
        {
            if (IsExistingUser(login)){
            
            LoginDto user = _context.Login.First(c => c.EmailAddress == login.EmailAddress);
                return user;
            }
            return null;
        }

        public LoginDto Create(LoginDto login)
        {
            if (!IsExistingUser(login))
            {
                _context.Login.Add(login);
                _context.SaveChanges();
                return login;
            }
            //todo redirect to get user
            return null;
        }

        public bool IsExistingUser(LoginDto login)
        {
            LoginDto user = _context.Login.First(c => c.EmailAddress == login.EmailAddress);
            if (user == null)
                return false;

            return true;
        }
    }
}
