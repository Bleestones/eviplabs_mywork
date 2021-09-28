
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
