using Medication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entites;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public async Task<IEnumerable<User>> getAllUsers()
        {
            return await _userRepository.getAllUsers();
        }
        public async Task<User> getUser(string userName, string password)
        {
            return await _userRepository.getUser(userName, password);
        }
        public async Task<User> addUser(User user)
        {
            return await _userRepository.addUser(user);
        }
        public async Task  updateUser(User user)
        {
             await _userRepository.updateUser(user);
            return;
        }

        public async Task<User> getUserById(int userId)
        {
            return await _userRepository.getUserById(userId);
        }
    }
}
