using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> Get(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
