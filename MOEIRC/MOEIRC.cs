using System;

namespace MOEIRC
{
    public class MOEIRC
    {

        public string Login { get; set; }
        public string Password { get; set; }

        public MOEIRC(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

    }
}
