using Business.Abstract;
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

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> Get(int id)
        {
            return _brandDal.GetAll(b => b.Id == id);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Insert(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
