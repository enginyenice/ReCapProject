﻿/*Created By Engin Yenice
enginyenice2626@gmail.com*/

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
    public class EfCarDal : EfRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                             join c in context.Colors
                             on p.ColorId equals c.Id
                             join d in context.Brands
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