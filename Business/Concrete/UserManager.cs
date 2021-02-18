﻿/*
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
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public Result Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.AddUserMessage);
        }

        public Result Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.DeleteUserMessage);
        }

        public DataResult<User> Get(int id)
        {
            User user = _userDal.Get(p => p.Id == id);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.GetErrorUserMessage);
            }
            else
            {
                return new SuccessDataResult<User>(user, Messages.GetSuccessUserMessage);
            }
        }

        public DataResult<List<User>> GetAll()
        {
            List<User> users = _userDal.GetAll();
            if (users.Count == 0)
            {
                return new ErrorDataResult<List<User>>(Messages.GetErrorUserMessage);
            }
            else
            {
                return new SuccessDataResult<List<User>>(users, Messages.GetSuccessUserMessage);
            }
        }

        public DataResult<User> GetByEmail(string email)
        {
            User user = _userDal.Get(p => p.Email == email);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.GetErrorUserMessage);
            }
            else
            {
                return new SuccessDataResult<User>(user, Messages.GetSuccessUserMessage);
            }
        }

        [ValidationAspect(typeof(UserValidator))]
        public Result Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.EditUserMessage);
        }
    }
}