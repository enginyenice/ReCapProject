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
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public Result Add(Rental entity)
        {
            try
            {
                var isDeliveryControl = IsDelivery(entity.CarId);
                if (isDeliveryControl.Success)
                {
                    _rentalDal.Add(entity);
                    return new SuccessResult(Messages.AddRentalMessage);
                }
                else
                {
                    return new ErrorResult(isDeliveryControl.Message);
                }
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorRentalFKMessage);
            }
        }

        public Result Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.DeleteRentalMessage);
        }

        public DataResult<Rental> Get(int id)
        {
            Rental rental = _rentalDal.Get(p => p.Id == id);
            if (rental == null)
            {
                return new ErrorDataResult<Rental>(Messages.GetErrorRentalMessage);
            }
            else
            {
                return new SuccessDataResult<Rental>(rental, Messages.GetSuccessRentalMessage);
            }
        }

        public DataResult<List<Rental>> GetAll()
        {
            List<Rental> rentals = _rentalDal.GetAll();
            if (rentals.Count == 0)
            {
                return new ErrorDataResult<List<Rental>>(Messages.GetErrorRentalMessage);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(rentals, Messages.GetSuccessRentalMessage);
            }
        }

        public DataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails();
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos, Messages.GetSuccessRentalMessage);
            else
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.GetErrorRentalMessage);
        }

        public DataResult<List<RentalDetailDto>> GetAllUndeliveredRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails(p => p.ReturnDate == null);
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos, Messages.GetSuccessRentalMessage);
            else
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.GetErrorRentalMessage);
        }

        public DataResult<List<RentalDetailDto>> GetAllDeliveredRentalDetails()
        {
            List<RentalDetailDto> rentalDetailDtos = _rentalDal.GetAllRentalDetails(p => p.ReturnDate != null);
            if (rentalDetailDtos.Count > 0)
                return new SuccessDataResult<List<RentalDetailDto>>(rentalDetailDtos, Messages.GetSuccessRentalMessage);
            else
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.GetErrorRentalMessage);
        }

        public DataResult<bool> IsDelivery(int carId)
        {
            Rental isDeliveryCar = _rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null);
            if (_rentalDal.Get(p => p.CarId == carId && p.ReturnDate == null) != null)
                return new ErrorDataResult<bool>(false, Messages.CarNotAvaible);
            else
                return new SuccessDataResult<bool>(true, Messages.CarAvaible);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public Result Update(Rental entity)
        {
            try
            {
                _rentalDal.Update(entity);
                return new SuccessResult(Messages.EditRentalMessage);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.ErrorRentalFKMessage);
            }
        }
    }
}