using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class UserRepository : IRepository<IUser>
    {

        private List<IUser> users;

        public UserRepository()
        {
            users = new List<IUser>();  
        }
        public void AddModel(IUser user)
        {
            users.Add(user);
        }
        public bool RemoveById(string identifier)
        {
            return users.Remove(users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier));
        }
        public IUser FindById(string identifier)
        {
            return users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
        }

        public IReadOnlyCollection<IUser> GetAll() => users;

    }
}
