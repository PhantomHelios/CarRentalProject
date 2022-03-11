using Business.Abstract;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> Get(int id)
        {
            return _carDal.GetAll(c => c.CarId == id);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Insert(Car car)
        {
            if (car == null)
                return;

            if (car.Description.Length < 2)
            {
                Console.WriteLine("Car name must be at least lentgh of 2!");
                return;
            }
            if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Daily price must be a positive value!");
                return;
            }

            _carDal.Add(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
