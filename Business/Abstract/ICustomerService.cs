/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<Customer> Get(int id);

        IResult Add(Customer entity);

        IResult Update(Customer entity);

        IResult Delete(Customer entity);
    }
}