/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService : IBaseService<Rental>
    {
        IResult DeliverTheCar(int carId);

        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();

        IDataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails();

        IDataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails();
    }
}