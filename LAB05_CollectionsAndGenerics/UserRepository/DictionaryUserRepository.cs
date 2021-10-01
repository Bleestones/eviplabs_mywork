using System;
using System.Collections.Generic;

namespace UserRepository
{
    public class DictionaryUserRepository : IUserRepository
    {
        Dictionary<string, User> users = new Dictionary<string, User>();
        public int Count()
        {
            return 0;
        }

        public User Get(int index)
        {
            // Ez nem NotImplementedException, mert nem is cél, hogy megvalósítsuk!
            //  A dictionary jellegéből adódóan nem alkalmas erre.
            throw new NotSupportedException();
        }

        public User GetById(string id)
        {
            return users.GetValueOrDefault(id);
        }

        public void Insert(User user)
        {
            users.Add(user.Id, user);
        }
    }
}

