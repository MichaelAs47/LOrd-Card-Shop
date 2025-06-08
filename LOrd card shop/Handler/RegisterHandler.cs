using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Factory;
using LOrd_card_shop.Model;
using LOrd_card_shop.Repository;

namespace LOrd_card_shop.Handler
{
    public class RegisterHandler
    {
        private RegisterFactory _RegisFactory;
        private ResgisterRepo _RegisRepo;

        public RegisterHandler()
        {
            _RegisFactory = new RegisterFactory();
            _RegisRepo = new ResgisterRepo();
        }

        public string registerUser(string username, string email, string password, string gender, DateTime DOB, string role)
        {
            if (_RegisRepo.getUserbyname(username) == null)
            {
                return _RegisRepo.insertnewUser(_RegisFactory.create(username, email, password, gender, DOB, role));
            }
            return "User must be unique";
        }

        public List<User> GetAllUser()
        {
            return _RegisRepo.GetAll();
        }

        public string EditUser(User user, string userName, string userEmail, string userGender, string userPass)
        {
            _RegisRepo.EditingUser(user, userName, userEmail, userGender, userPass);
            return "Edit successful";
        }

        public User GetUserId(int id)
        {
            return _RegisRepo.GetUserById(id);
        }

        public User GetUsername(string username)
        {
            return _RegisRepo.GetUserbyname(username);
        }

        public User GetEmail(string email)
        {
            return _RegisRepo.GetUserByEmail(email);
        }

        public User FindUserById(int id)
        {
            return _RegisRepo.FindUserById(id);
        }
    }
}