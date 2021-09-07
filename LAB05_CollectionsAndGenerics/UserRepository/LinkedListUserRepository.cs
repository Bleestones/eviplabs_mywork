using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserRepository
{
    public class LinkedListUserRepository : IUserRepository
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
                if (string.Compare(this.Get(mid).Id, id) > 0)
                {
                    right = mid - 1;
                }
                else if (string.Compare(this.Get(mid).Id, id) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    return users.ElementAt(mid);
                }
            } */
            return null;
        }

        public void Insert(User user)
        {
            // A string.Compare segítségével keresd meg, hova kell beszúrni az új usert.
        }
    }
}
