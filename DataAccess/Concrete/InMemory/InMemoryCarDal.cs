using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 50, Description = "Ferrari", ModelYear = 2020},                
                new Car{CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 50, Description = "Alpha Romeo", ModelYear = 2020},
                new Car{CarId = 3, BrandId = 1, ColorId = 3, DailyPrice = 200, Description = "Porsche", ModelYear = 2022},
                new Car{CarId = 4, BrandId = 2, ColorId = 5, DailyPrice = 100, Description = "Mustang", ModelYear = 2000},
                new Car{CarId = 5, BrandId = 3, ColorId = 3, DailyPrice = 150, Description = "Corolla", ModelYear = 2015},
                new Car{CarId = 6, BrandId = 4, ColorId = 4, DailyPrice = 10, Description = "Sahin", ModelYear = 2000},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            if(carToUpdate != null)
            {
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ModelYear = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
            }
        }
    }
}
