using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class ListUserRepository : IUserRepository
    {
        public int Count()
        {
            return 0;
        }

        public User Get(int index)
        {
            // Tipp: használd az indexer "[]" operátort!
            return null;
        }

        public User GetById(string id)
        {
            return null;
        }

        public void Insert(User user)
        {
        }
    }
}
