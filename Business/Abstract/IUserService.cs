/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        DataResult<User> GetByEmail(string email);
    }
}