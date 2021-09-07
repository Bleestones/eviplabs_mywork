using System;
using System.Collections.Generic;
using System.Text;

namespace UserRepository
{
    public interface IUserRepository
    {
        int Count();

        User Get(int index);

        void Insert(User user);

        User GetById(string id);
    }
}
