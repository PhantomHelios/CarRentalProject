using Business.Abstract;
using Business.Constants;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> Get(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.Id == id));
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IResult Add(Brand brand)
        {
            try
            {
                _brandDal.Add(brand);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
