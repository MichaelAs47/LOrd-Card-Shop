using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Factory
{
    public class RegisterFactory
    {
        public User create(string username, string email, string password, string gender, DateTime DOB, string Role)
        {
            return new User()
            {
                UserName = username,
                UserEmail = email,
                UserPassword = password,
                UserGender = gender,
                UserDOB = DOB,
                UserRole = Role
            };
        }
    }
}