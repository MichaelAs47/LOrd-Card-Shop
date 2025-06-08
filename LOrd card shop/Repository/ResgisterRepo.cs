using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrd_card_shop.Model;

namespace LOrd_card_shop.Repository
{
    public class ResgisterRepo
    {
        private Database1Entities1 db;

        public ResgisterRepo()
        {
            db = new Database1Entities1();
        }

        public string insertnewUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return "Registration successful! Redirecting to login...";
        }

        public User getUserbyname(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User GetUserbyname(string username)
        {
            return db.Users.Where(u => u.UserName == username).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return db.Users.Where(u => u.UserID == id).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.Where(u => u.UserEmail == email).FirstOrDefault();
        }

        public User FindUserById(int id)
        {
            return db.Users.Find(id);
        }

        public void DeleteUser(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void EditingUser(User user, string username, string useremail, string usergender, string password)
        {
            User editUser = GetUserById(user.UserID);
            editUser.UserName = username;
            editUser.UserEmail = useremail;
            editUser.UserGender = usergender;
            editUser.UserPassword = password;
            db.SaveChanges();
        }
    }
}