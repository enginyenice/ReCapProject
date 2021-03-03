/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using System;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheRemoveAspect("Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            _carDal.Add(entity);
            return new SuccessResult(Messages.AddCarMessage);
        }

        [CacheRemoveAspect("Get")]
        [TransactionAspect]
        [PerformanceAspect(0)]
        public IResult AddTransactionTest(Car entity)
        {
            _carDal.Add(entity);
            if (entity.BrandId == 1002)
            {
                throw new Exception("");
            }

            entity.Id = 0;
            entity.Description = "TransactionTest" + entity.Description;
            _carDal.Add(entity);
            return new SuccessResult(Messages.AddCarMessage);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.DeleteCarMessage);
        }

        public IDataResult<Car> Get(int id)
        {
            Car car = _carDal.Get(p => p.Id == id);
            if (car == null)
            {
                return new ErrorDataResult<Car>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<Car>(car, Messages.GetSuccessCarMessage);
            }
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            List<Car> cars = _carDal.GetAll();
            if (cars.Count == 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(cars, Messages.GetSuccessCarMessage);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            List<Car> cars = _carDal.GetAll(p => p.BrandId == brandId);
            if (cars == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(cars, Messages.GetErrorCarMessage);
            }
        }

        public IDataResult<List<Car>> GetCarsByCarId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            List<Car> cars = _carDal.GetAll(p => p.ColorId == colorId);
            if (cars == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(cars, Messages.GetErrorCarMessage);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetail()
        {
            List<CarDetailDto> carDetails = _carDal.GetCarsDetail();
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.GetErrorCarMessage);
            }
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.EditCarMessage);
        }
    }
}