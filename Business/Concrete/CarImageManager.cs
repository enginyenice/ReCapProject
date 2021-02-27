﻿/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileProcess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly ICarService _carService;
        private readonly IFileProcess _fileProcess;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService, IFileProcess fileProcess)
        {
            _carImageDal = carImageDal;
            _carService = carService;
            _fileProcess = fileProcess;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage entity, IFormFile file)
        {
            var result = BusinessRules.Run(
                CheckIfImageLength(file),
                CheckCarImageCount(entity.CarID),
                CheckIfFileExtension(file));
            if (result != null)
            {
                return result;
            }
            var fileResult = _fileProcess.Upload(DefaultNameOrPath.ImageDirectory, file);

            if (!fileResult.Success)
            {
                return new ErrorResult(Messages.AddErrorCarMessage);
            }

            entity.ImagePath = fileResult.Data;
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.AddCarImageMessage);
        }

        public IResult Delete(CarImage entity)
        {
            var imageData = _carImageDal.Get(p => p.Id == entity.Id);
            _fileProcess.Delete(imageData.ImagePath);
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

        public IResult Update(CarImage entity, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(entity.CarID),
                CheckIfFileExtension(file));
            if (result != null)
            {
                return result;
            }

            if (file.Length > 0)
            {
                _fileProcess.Delete(entity.ImagePath);
                var uploadResult = _fileProcess.Upload(DefaultNameOrPath.ImageDirectory, file);
                entity.ImagePath = uploadResult.Data;
            }

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
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { new CarImage { ImagePath = DefaultNameOrPath.ImageDefaultPath } });
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

        private IResult CheckIfImageLength(IFormFile file)
        {
            if (file.Length == 0)
            {
                return new ErrorResult(Messages.ImageNotFound);
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

        private IResult CheckIfFileExtension(IFormFile file)
        {
            string acceptableExtensions = ".png|.jpeg|.jpg";
            if (String.Compare(Path.GetExtension(file.Name), acceptableExtensions) == 0 || file.Length == -1)
            {
                return new ErrorResult(Messages.IncorrectFileExtension);
            }
            return new SuccessResult();
        }

        #endregion Car Image Business Rules
    }
}