using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car, EfContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (EfContext context = new EfContext())
            {
                var result = from p in filter == null ? context.Car : context.Car.Where(filter)
                             join c in context.Color
                             on p.ColorId equals c.Id
                             join d in context.Brand
                             on p.BrandId equals d.Id
                             select new CarDetailDto
                             {
                                 BrandName = d.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 ModelYear = p.ModelYear,
                                 CarId = p.Id
                             };
                return result.ToList();
            }
        }
    }
}