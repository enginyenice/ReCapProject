/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBaseService<T> where T : IEntity
    {
        IDataResult<List<T>> GetAll();

        IDataResult<T> Get(int id);

        IResult Add(T entity);

        IResult Update(T entity);

        IResult Delete(T entity);
    }
}