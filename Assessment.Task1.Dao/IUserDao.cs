using Assessment.Task1.Models;

namespace Assessment.Task1.Dao
{
    public interface IUserDao
    {
        List<IndexModel> GetUsers();
    }
}