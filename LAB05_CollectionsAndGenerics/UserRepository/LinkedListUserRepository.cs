using System.Collections.Generic;
using System.Linq;

namespace UserRepository
{
    public class LinkedListUserRepository : IUserRepository
    {
        LinkedList<User> users = new LinkedList<User>();
        public int Count()
        {
            return 0;
        }

        public User Get(int index)
        {
            return users.ElementAt(index);
        }

        public User GetById(string id)
        {
            // Binaris kereses rendezett tombon
            var left = 0;
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
            }
            return null;
        }

        public void Insert(User user)
        {
            // A string.Compare segítségével keresd meg, hova kell beszúrni az új usert.
            LinkedListNode<User> userNode = null;
            foreach (User u in users)
            {
                if (user.Id.CompareTo(u.Id) < 0)
                {
                    userNode = users.Find(u);
                    break;
                }
            }
            //O(1) muveletek
            if (userNode is null)
                users.AddLast(user);
            else
                users.AddBefore(userNode, user);
        }
    }
}
