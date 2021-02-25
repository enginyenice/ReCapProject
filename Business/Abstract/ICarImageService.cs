/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService : IBaseService<CarImage>
    {
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}