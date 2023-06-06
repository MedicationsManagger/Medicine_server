using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entites;
using Medication;

namespace Repository
{
    public class UserRepository: IUserRepository
    {
        MedicationsContext _medicationsContext;
        public UserRepository(MedicationsContext medicationsContext)
        {
            _medicationsContext = medicationsContext;
        }

        public async Task< IEnumerable<User>>getAllUsers()
        {
            var users = (from u in _medicationsContext.Users
                         select u).ToList();
            return users;
        }

        public async Task<User> getUser(string userName, string password)
        {
            var user = (from u in _medicationsContext.Users
                        where u.EmailAddress == userName & u.Password == password
                        select u);

            return user.FirstOrDefault();
            
        }
        public async Task <User> addUser(User user)
        {
            await _medicationsContext.Users.AddAsync(user);
            await _medicationsContext.SaveChangesAsync();
            return user;

        }
        public async Task  updateUser(User user)
        {
           var userToUpdate =await _medicationsContext.Users.FindAsync(user.Id);
            if (userToUpdate == null) {
                return;  
            }
            _medicationsContext.Entry(userToUpdate).CurrentValues.SetValues(user);
            await _medicationsContext.SaveChangesAsync();
            return;

        }

        public async Task<User> getUserById(int userId)
        {
            var user = (from u in _medicationsContext.Users
                        where u.Id==userId
                        select u);

            return user.FirstOrDefault();
        }
    }
}
