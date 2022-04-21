using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 ColorName = color.Name,
                                 Description = car.Description,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 CarId = car.CarId,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             where car.BrandId == id
                             select new CarDetailDto
                             {
                                 ColorName = color.Name,
                                 Description = car.Description,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 CarId = car.CarId,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByColorId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             where car.ColorId == id
                             select new CarDetailDto
                             {
                                 ColorName = color.Name,
                                 Description = car.Description,
                                 BrandName = brand.Name,
                                 DailyPrice = car.DailyPrice,
                                 CarId = car.CarId,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();
            }
        }

    }
}
