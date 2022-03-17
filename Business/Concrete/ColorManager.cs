using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Delete(Color color)
        {
            try{
                _colorDal.Delete(color);
            }
            catch{
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorExists(color.Name));
            if (result != null)
                return result;

            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
            }
            catch
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult CheckIfColorExists(string name)
        {
            return _colorDal.GetAll(c => c.Name == name).Any() ? new ErrorResult() : new SuccessResult();
        }
    }
}
