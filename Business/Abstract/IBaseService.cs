/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : IEntity
    {
        DataResult<List<T>> GetAll();

        DataResult<T> Get(int id);

        Result Add(T entity);

        Result Update(T entity);

        Result Delete(T entity);
    }
}