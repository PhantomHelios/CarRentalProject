using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerService _customerService;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICustomerService customerService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarExists(rental.CarId),
                CheckIfCustomerExists(rental.CustomerId), CheckIfCarIsRented(rental));
            if (result != null)
                return result;

            _rentalDal.Add(rental);
            

            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            
            _rentalDal.Delete(rental);
            
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == id));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll(r => r.Id == id).First());
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarExists(rental.CarId),
                CheckIfCustomerExists(rental.CustomerId), CheckIfCarIsRented(rental));
            if (result != null)
                return result;

            _rentalDal.Update(rental);
            
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult CheckIfCarIsRented(Rental rental)
        {
            var controller = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            
            return controller.Count > 0 ? new ErrorResult(Messages.CarAlreadyRented)
                : new SuccessResult();
        }

        public IResult CheckIfCustomerExists(int customerId)
        {
            return _customerService.Get(customerId).Success ? new SuccessResult() : new ErrorResult();
        }

        public IResult CheckIfCarExists(int carId)
        {
            return _carService.Get(carId).Success ? new SuccessResult() : new ErrorResult();
        }
    }
}
