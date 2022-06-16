using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Repository
{
    public class IRepository
    {
        public string searchByName = string.Empty;
        public string searchByRole = string.Empty;
        public int searchById = -1;
        
        
        private List<User> users = new () {
            new User { id = 1, role = "admin", name = "erick"},
            new User { id = 2, role = "developer", name = "rudy"},
            new User { id = 3, role = "admin", name = "pedro"},
        };

        public List<User> GetUsers()
        {
            if (searchByName != string.Empty)
                return users.Where(x => x.name.Equals(searchByName)).ToList();

            if (searchByRole != string.Empty)
                return users.Where(x => x.role.Equals(searchByRole)).ToList();

            if (searchById > -1)
                return users.Where(x => x.id.Equals(searchById)).ToList();

            return users;
        }
    }
}