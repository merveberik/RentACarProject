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
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
