using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            try
            {
                _customerDal.Add(customer);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

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
            try
            {
                _customerDal.Update(customer);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
