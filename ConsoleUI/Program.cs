using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(String[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            
            carManager.AddCar(new Car { BrandId = 2, ColorId = 4, DailyPrice = 80, Description = "Civic Turbo", ModelYear = 2022});
            carManager.AddCar(new Car { BrandId = 1, ColorId = 4, DailyPrice = -20, Description = "i10", ModelYear = 2022 });
            carManager.AddCar(new Car { BrandId = 1, ColorId = 4, DailyPrice = 200, Description = "i", ModelYear = 2022 });
        }
    }
}