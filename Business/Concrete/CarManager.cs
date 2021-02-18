/*
Created By Engin Yenice
enginyenice2626@gmail.com
*/

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public Result Add(Car entity)
        {
            _carDal.Add(entity);
            return new SuccessResult(Messages.AddCarMessage);
        }

        public Result Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.DeleteCarMessage);
        }

        public DataResult<Car> Get(int id)
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

        public DataResult<List<Car>> GetAll()
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

        public DataResult<List<Car>> GetCarsByBrandId(int brandId)
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

        public DataResult<List<Car>> GetCarsByColorId(int colorId)
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

        public DataResult<List<CarDetailDto>> GetCarsDetail()
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
        public Result Update(Car entity)
        {
            try
            {
                _carDal.Update(entity);
                return new SuccessResult(Messages.EditCarMessage);
            }
            catch
            {
                return new ErrorResult(Messages.ErrorCarFKMessage);
            }
        }
    }
}