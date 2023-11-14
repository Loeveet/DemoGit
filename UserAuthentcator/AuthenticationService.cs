using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticator
{
    public class AuthenticationService
    {
        private readonly IMailService _mailService;
        private readonly IDatabase _database;

        public AuthenticationService(IMailService mailService, IDatabase database)
        {
            this._mailService = mailService;
            this._database = database;
        }

        public User Register(string name, string email) 
        {
            var user = new User()
            {
                Name = name,
                Email = email,
                Password = "password"
            };

            _database.AddUser(user);
            _mailService.SendPassword(user.Email, user.Password);

            return user;
        }
        public bool Login(string username, string password)
        {
            var user = new User();
            try
            {
                user = _database.GetUser(username);

            }
            catch (Exception)
            {
                // log and return fail
                return false;
            }
            return (user.Password == password);                
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }
        public void ChangePassword(User user)
        {
            throw new NotImplementedException();
        }
        
    }
}
