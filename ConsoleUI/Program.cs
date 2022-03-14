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
            //BrandTest();

            //UserTest();
            //CustomerTest();
            RentalTest();
        }

        public static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var test = rentalManager.GetRentalDetails();

            foreach (var rental in test.Data)
                Console.WriteLine(rental.CustomerFirstName + " " + rental.CarModel);
        }

        public static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetCustomerDetails();

            if(result.Success)
                foreach(var customer in result.Data)
                    Console.WriteLine(customer.CustomerFirstName + " " + customer.CustomerLastName + " => " + customer.CompanyName);
        }

        public static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            if (result.Success)
                foreach (var user in result.Data)
                    Console.WriteLine(user.FirstName + " " + user.LastName);
        }

        public static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                    Console.WriteLine(car.BrandName + " " + car.CarName);
            }
            else
                Console.WriteLine(result.Message);
        }

        public static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success)
                foreach (var brand in result.Data)
                    Console.WriteLine(brand.Name);
            else
                Console.WriteLine(result.Message);
            
        }

        public static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            if (result.Success)
                foreach (var color in result.Data)
                    Console.WriteLine(color.Name);
            else
                Console.WriteLine(result.Message);
        }
    }
}