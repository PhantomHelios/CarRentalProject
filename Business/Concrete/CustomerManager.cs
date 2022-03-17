using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserService _userService;
        public CustomerManager(ICustomerDal customerDal, IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            var result = BusinessRules.Run(CheckIfUserExists(customer.UserId), CheckIfCustomershipExists(customer));
            if (result != null)
                return result;

            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<Customer> Get(int id)
        {
            Customer customer = _customerDal.GetCustomerByID(id);

            return customer == null ? new ErrorDataResult<Customer>() 
                : new SuccessDataResult<Customer>(customer);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.getCustomerDetails());
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            var result = BusinessRules.Run(CheckIfUserExists(customer.UserId));
            if (result != null)
                return result;

            _customerDal.Update(customer);
            
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult CheckIfUserExists(int userId)
        {
            return _userService.Get(userId).Success ? new ErrorResult() : new SuccessResult();
        }

        public IResult CheckIfCustomershipExists(Customer customer)
        {
            return _customerDal.Get(c => c.UserId == customer.UserId && c.CompanyName == customer.CompanyName) == null
                ? new ErrorResult(Messages.CustomershipAlreadyExist) : new SuccessResult();
        }
    }
}
