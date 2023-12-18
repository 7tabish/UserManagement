using AutoMapper;
using OA.Data;
using OA.Repository;

namespace OA.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<UserModel> _userRespository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository<UserModel> userRepository, IMapper mapper)
        {
            _userRespository = userRepository;
            _mapper = mapper;
        }
        public int AddUser(UserDTO user)
        {
            //map DTO to model
            UserModel userModel = _mapper.Map<UserModel>(user);
            _userRespository.AddUser(userModel);
            return userModel.ID;
        }
        public bool DeleteUser(int ID)
        {
            var user = _userRespository.GetUserById(ID);
            if (user!=null)
            {
                return _userRespository.DeleteUser(user);
            }
            return false;
        }
        public UserOutputDTO GetUserById(int id)
        {
            UserModel user = _userRespository.GetUserById(id);
            return _mapper.Map<UserOutputDTO>(user);
        }
        public List<UserOutputDTO> GetUsers()
        {
            List<UserModel> users = _userRespository.GetUsers();
            return _mapper.Map<List<UserOutputDTO>>(users);
        }
        public UserOutputDTO UpdateUser(int userID, UserDTO user)
        {
            UserModel existingUser = _userRespository.GetUserById(userID);
            UserOutputDTO res = null;
            if (existingUser != null)
            {
                //map the input to model
                UserModel updatedUser = _mapper.Map<UserModel>(user);
                updatedUser.ID = existingUser.ID;
                _userRespository.UpdateUser(updatedUser);
                res = _mapper.Map<UserOutputDTO>(updatedUser);
            }
            return res;
        }
    }
}
