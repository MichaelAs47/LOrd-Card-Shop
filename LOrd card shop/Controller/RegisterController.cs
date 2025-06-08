using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Handler;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Controller
{
    public class RegisterController
    {
        private RegisterHandler _RegisHandler;

        public RegisterController()
        {
            _RegisHandler = new RegisterHandler();
        }

        public List<User> GetAll()
        {
            return _RegisHandler.GetAllUser();
        }
        public User GetUsername(string username)
        {
            return _RegisHandler.GetUsername(username);
        }
        public User GetEmail(string email)
        {
            return _RegisHandler.GetEmail(email);
        }

        public User GetUserId(int id)
        {
            return _RegisHandler.GetUserId(id);
        }

        public User FindUserById(int id)
        {
            return _RegisHandler.FindUserById(id);
        }

        public string UserNameValidate(string userName)
        {
            if (userName == "") return "Username still empty";
            if (GetUsername(userName) != null) return "Username already exist";
            if (userName.Length > 30 || userName.Length < 5) return "Username must be 5-30 characters";

            foreach (char c in userName)
            {
                if (!char.IsLetter(c) && c != ' ') return "Username must be alphabet and space only";
            }

            return "";
        }

        public string UserEmailValidate(string userEmail)
        {
            if (userEmail == "") return "Email still empty";
            if (GetEmail(userEmail) != null) return "Email already exist";
            if (!userEmail.Contains("@")) return "Email must use '@' ";
            return "";
        }

        public string UserPassValidate(string userPass)
        {
            if (userPass == "") return "Password still empty";
            if (userPass.Length < 8) return "Password must at least 8 characters";

            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in userPass)
            {
                if (char.IsLetter(c)) hasLetter = true;
                if (char.IsDigit(c)) hasDigit = true;
            }

            if (!hasLetter || !hasDigit)
                return "Password must contain both letters and digits";

            return "";
        }

        public string UserConfirmValidate(string userPass, string confirm)
        {
            if (confirm == "") return "Confirm still empty";
            if (confirm != userPass) return "Confirm pass and user pass is different";
            return "";
        }

        public string UserOldValidate(string userPass, string oldpass)
        {
            if (oldpass == "") return "Old Pass still empty";
            if (oldpass != userPass) return "Old pass and user pass is different";
            return "";
        }

        public string UserGenderValidate(string userGender)
        {
            if (userGender == "") return "Gender must selected";
            return "";
        }

        public string UserUpdateEmailValidate(string newUserEmail, string currentUserEmail)
        {
            if (newUserEmail == "") return "Email still empty";
            if (!newUserEmail.Contains("@")) return "Email must contain '@'";

            if (newUserEmail != currentUserEmail && GetEmail(newUserEmail) != null)
                return "Email already exists";

            return "";
        }

        public string UserUpdateNameValidate(string newUserName, string currentUserName)
        {
            if (newUserName == "") return "Username still empty";
            if (newUserName.Length > 30 || newUserName.Length < 5) return "Username must be 5-30 characters";

            foreach (char c in newUserName)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return "Username must be alphabet and space only";
            }

            if (newUserName != currentUserName && GetUsername(newUserName) != null)
                return "Username already exists";

            return "";
        }


        public string RegisterUser(string username, string email, string password, string confirmPass, string gender, DateTime DOB, string Role)
        {
            string result;

            result = UserNameValidate(username);
            if (result != "") return result;

            result = UserEmailValidate(email);
            if (result != "") return result;

            result = UserPassValidate(password);
            if (result != "") return result;

            result = UserConfirmValidate(password, confirmPass);
            if (result != "") return result;

            result = UserGenderValidate(gender);
            if (result != "") return result;

            return _RegisHandler.registerUser(username, email, password, gender, DOB, Role);
        }

        public string EditUser(User user, string userName, string userEmail, string userGender, string oldPass, string newPass, string confPass)
        {
            string result;

            result = UserUpdateNameValidate(userName, user.UserName);
            if (result != "") return result;

            result = UserUpdateEmailValidate(userEmail, user.UserEmail);
            if (result != "") return result;

            result = UserGenderValidate(userGender);
            if (result != "") return result;

            if (!string.IsNullOrEmpty(newPass))
            {
                result = UserOldValidate(user.UserPassword, oldPass);
                if (result != "") return result;

                result = UserPassValidate(newPass);
                if (result != "") return result;

                result = UserConfirmValidate(newPass, confPass);
                if (result != "") return result;
            }

            string finalPassword = string.IsNullOrEmpty(newPass) ? user.UserPassword : newPass;

            return _RegisHandler.EditUser(user, userName, userEmail, userGender, finalPassword);
        }
    }
}