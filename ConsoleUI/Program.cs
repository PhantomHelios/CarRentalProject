using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(String[] args)
        {
            //ColorTest();
            //CarTest();
            BrandTest();
        }

        public static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
                Console.WriteLine(car.BrandName + " " + car.CarName);

            Car newCar = new Car { BrandId = 1, ColorId = 1, DailyPrice = 111, Description = "Tucson", ModelYear = 2019 };

            carManager.Insert(newCar);
            Console.WriteLine("\nAdded\n");

            foreach (var car in carManager.GetCarDetails())
                Console.WriteLine(car.BrandName + " " + car.CarName);

            newCar.Description = "i30";
            carManager.Update(newCar);
            Console.WriteLine("\nUpdated\n");

            foreach (var car in carManager.GetCarDetails())
                Console.WriteLine(car.BrandName + " " + car.CarName);

            carManager.Delete(newCar);
            Console.WriteLine("\nDeleted\n");

            foreach (var car in carManager.GetCarDetails())
                Console.WriteLine(car.BrandName + " " + car.CarName);

        }

        public static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
                Console.WriteLine(brand.Name);

            Brand newBrand = new Brand { Name = "BMC" };
            brandManager.Insert(newBrand);
            Console.WriteLine("\nAdded\n");

            foreach (var brand in brandManager.GetAll())
                Console.WriteLine(brand.Name);

            newBrand.Name = "BMC Auto";
            brandManager.Update(newBrand);
            Console.WriteLine("\nUpdated\n");

            foreach (var brand in brandManager.GetAll())
                Console.WriteLine(brand.Name);

            brandManager.Delete(newBrand);
            Console.WriteLine("\nDeleted\n");

            foreach (var brand in brandManager.GetAll())
                Console.WriteLine(brand.Name);
        }

        public static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
                Console.WriteLine(color.Name);

            Color newColor = new Color { Name = "Purple" };
            colorManager.Insert(newColor);

            Console.WriteLine("\nAdded\n");

            foreach (var color in colorManager.GetAll()) {
                Console.WriteLine(color.Name);

                if (color.Name == "Purple")
                    newColor = color;
            }
            newColor.Name = "Purpl";
            colorManager.Update(newColor);

            Console.WriteLine("\nUpdated\n");

            foreach (var color in colorManager.GetAll())
                Console.WriteLine(color.Name);

            colorManager.Delete(newColor);

            Console.WriteLine("\nDeleted\n");

            foreach (var color in colorManager.GetAll())
                Console.WriteLine(color.Name);

        }
    }
}