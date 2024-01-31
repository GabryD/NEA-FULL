using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Password_manager
{
    public class Information
    {
        private string website;
        private string username;
        private string password;

        public string Website
        {
            get { return website; }
            set { website = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
