/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        IDataResult<User> GetByEmail(string email);
    }
}