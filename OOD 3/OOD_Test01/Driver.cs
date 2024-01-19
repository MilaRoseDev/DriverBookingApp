using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
    class Driver
    {
        protected string userName;
        protected string passWord;

        public Driver(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        public bool CheckPassword(string password)
        {
            if (passWord == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public string GetUserName()
       {
           return userName;
       }
    }
}
