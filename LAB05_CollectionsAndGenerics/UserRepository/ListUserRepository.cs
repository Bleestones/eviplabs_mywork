using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class ListUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        public int Count()
        {
            return 0;
        }

        public User Get(int index)
        {
            // Tipp: használd az indexer "[]" operátort!
            return users[index];
        }

        public User GetById(string id)
        {
            foreach (User u in users)
                if (u.Id.Equals(id))
                    return u;
            return null;
        }

        public void Insert(User user)
        {
            users.Add(user);
        }
    }
}
