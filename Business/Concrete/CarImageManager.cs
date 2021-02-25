/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage entity)
        {
            var result = BusinessRules.Run(
                CheckCarImageCount(entity.CarID),
                CheckIfFileExtension(entity.ImagePath));
            if (result != null)
            {
                return result;
            }

            string createPath = FilePaths.ImageFolderPath + Path.GetFileName(entity.ImagePath);
            File.Copy(entity.ImagePath, createPath);
            entity.ImagePath = createPath;
            entity.Date = DateTime.Now;
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
            var result = BusinessRules.Run(CheckCarImageCount(entity.CarID), CheckIfFileExtension(entity.ImagePath));
            if (result != null)
            {
                return result;
            }

            string createPath = FilePaths.ImageFolderPath + Path.GetFileName(entity.ImagePath);
            File.Delete(_carImageDal.Get(p => p.Id == entity.Id).ImagePath);
            File.Copy(entity.ImagePath, createPath);
            entity.ImagePath = createPath;
            entity.Date = DateTime.Now;

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

        #region Car Image Business Rules

        private IResult CheckCarImageCount(int carId)
        {
            if (_carImageDal.GetAll(p => p.CarID == carId).Count > 4)
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

        private IResult CheckIfFileExtension(string path)
        {
            string acceptableExtensions = ".png|.jpeg|.jpg";
            if (String.Compare(Path.GetExtension(path).ToLower(), acceptableExtensions) == 0)
            {
                return new ErrorResult(Messages.IncorrectFileExtension);
            }
            return new SuccessResult();
        }

        #endregion Car Image Business Rules
    }
}