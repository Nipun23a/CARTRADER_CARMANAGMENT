using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Models
{
    internal class User:IUser
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
        public string FirstName {  get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }   
    }

}
