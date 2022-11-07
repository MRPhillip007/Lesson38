using AdminPanel.Entities;
using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel.BLL.Services.UserService
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public void UpdateUser(UserEntity userEntity);
        public void SaveUser(UserEntity userEntity);
        public void DeleteUser (int id);
    }
}
