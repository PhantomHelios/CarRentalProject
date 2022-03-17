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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;
        IBrandService _brandService;
        public CarManager(ICarDal carDal, IColorService colorService, IBrandService brandService)
        {
            _carDal = carDal;
            _colorService = colorService;
            _brandService = brandService;
        }

        public IResult Delete(Car car)
        {
            try { 
                _carDal.Delete(car); 
            }
            catch { 
                return new ErrorResult(Messages.MaintenanceTime); 
            }

            return new SuccessResult(Messages.CarDeleted); 
        }

        public IDataResult<List<Car>> Get(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result != null)
                return result;

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = BusinessRules.Run(CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result != null)
                return result;

            _carDal.Update(car);
            
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult CheckIfBrandExists(int brandId)
        {
            return _brandService.Get(brandId).Success ? new SuccessResult() : new ErrorResult();
        }

        public IResult CheckIfColorExists(int colorId)
        {
            return _colorService.Get(colorId).Success ? new SuccessResult() : new ErrorResult();
        }
    }
}
