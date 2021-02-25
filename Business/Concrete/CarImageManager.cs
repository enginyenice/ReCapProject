/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        public IResult Add(CarImage entity)
        {
            var result = BusinessRules.Run(CheckCarImageCount());
            if (result != null)
            {
                return result;
            }

            string createPath = ImagePath(entity.CarID);
            File.Copy(entity.ImagePath, createPath);
            entity.ImagePath = createPath;
            _carImageDal.Add(entity);

            return new SuccessResult(Messages.AddCarImageMessage);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.Id == entity.Id);
            File.Delete(imageData.ImagePath);
            _carImageDal.Delete(imageData);
            return new SuccessResult(Messages.DeleteCarImageMessage);
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImage entity)
        {
            string createPath = ImagePath(entity.CarID);
            File.Copy(entity.ImagePath, createPath);
            File.Delete(entity.ImagePath);
            entity.ImagePath = createPath;
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.EditCarImageMessage);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarId(carId));
            if (result != null)
            {
                return (IDataResult<List<CarImage>>)result;
            }

            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarID == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = FilePaths.ImageDefaultPath } });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

        #region Car Image Business Codes

        private string ImagePath(int carId)
        {
            string GuidKey = Guid.NewGuid().ToString();
            return FilePaths.ImageFolderPath + GuidKey + ".jpeg";
        }

        #endregion Car Image Business Codes

        #region Car Image Business Rules

        private IResult CheckCarImageCount()
        {
            if (_carImageDal.GetAll().Count > 4)
            {
                return new ErrorResult(Messages.AboveImageAddingLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarId(int carId)
        {
            if (!_carService.Get(carId).Success)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.GetErrorCarMessage);
            }
            return new SuccessDataResult<List<CarImage>>();
        }

        #endregion Car Image Business Rules
    }
}