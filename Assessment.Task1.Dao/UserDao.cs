using Assessment.Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Task1.Dao
{
    public class UserDao : IUserDao
    {
        public List<IndexModel> GetUsers()
        {
            return new List<IndexModel>()
            {
                new IndexModel() { Username = "admin", Password = "admin" },
                new IndexModel() { Username = "user1", Password = "user1" }
            };
        }
    }
}
