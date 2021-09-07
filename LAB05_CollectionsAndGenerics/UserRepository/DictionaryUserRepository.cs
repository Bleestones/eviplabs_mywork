using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class DictionaryUserRepository : IUserRepository
    {
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
            return null;
        }

        public void Insert(User user)
        {
        }
    }
}

