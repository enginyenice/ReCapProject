﻿/*
Created By Engin Yenice
enginyenice2626@gmail.com
*/

using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null);
    }
}