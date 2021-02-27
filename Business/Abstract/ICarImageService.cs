/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();

        IDataResult<CarImage> Get(int id);

        IResult Add(CarImage entity, IFormFile file);

        IResult Update(CarImage entity, IFormFile file);

        IResult Delete(CarImage entity);

        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}