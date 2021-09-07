using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public class OrderedListUserRepository : IUserRepository
    {
        public int Count()
        {
            return 0;
        }

        public User Get(int index)
        {
            return null;
        }

        public User GetById(string id)
        {
            // Binaris kereses rendezett tombon
/*            var left = 0;
            var right = users.Count - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (string.Compare(users[mid].Id, id) > 0)
                {
                    right = mid - 1;
                }
                else if (string.Compare(users[mid].Id, id) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    return users[mid];
                }
            } */
            return null;
        }

        public void Insert(User user)
        {
        }
    }
}
