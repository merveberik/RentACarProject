using Business.Absrtact;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Absrtact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (_userDal.Get(c => c.UserId == user.UserId) == null)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }

            return new ErrorResult(Messages.UserInvalid);
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (ArgumentNullException)
            {
                return new ErrorResult(Messages.UserInvalid);
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == id));
        }

        public IResult Update(User user)
        {
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
