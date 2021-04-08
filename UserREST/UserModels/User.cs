using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModels
{
    public class User
    {
        //Data Fields
        private string userName;
        private string email;
        private string role;

        //Properties 
        public int Id { get; set; } //Id to identify users
        //UserName Property
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        //Email Property
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        //Role Property
        public string Role
        {
            get { return role; }
            set { role = value; }
        }


    }
}
