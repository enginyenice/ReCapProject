/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<Car> Get(int id);

        IResult Add(Car entity);

        IResult Update(Car entity);

        IResult Delete(Car entity);

        IDataResult<List<Car>> GetCarsByCarId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarsDetail();
    }
}