

using OA.Data;

namespace OA.Repository
{
    public  interface IUserRepository<T> where T : UserModel
    {
        public List<T> GetUsers();
        public T GetUserById(int userID);
        public void AddUser(T user);
        public bool UpdateUser(T user);
        public bool DeleteUser(T user);

    }
}
