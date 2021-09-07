using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public string Id { get; set; }

        public User(string firstname, string lastname, int age, string id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Id = id;
        }
    }
}
