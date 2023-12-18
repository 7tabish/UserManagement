using OA.Data;

namespace OA.Service
{
    public interface IUserService
    {
        public List<UserOutputDTO> GetUsers();
        public UserOutputDTO GetUserById(int userID);
        public int AddUser(UserDTO user);
        public UserOutputDTO UpdateUser(int userID, UserDTO user);
        public bool DeleteUser(int ID);
    }
}
