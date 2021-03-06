﻿/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<List<User>> GetAll();

        IDataResult<User> Get(int id);

        IResult Add(User entity);

        IResult Update(User entity);

        IResult Delete(User entity);

        IDataResult<User> GetByEmail(string email);
        IDataResult<UserBasicDto> GetByEmailDto(string email);
    }
}