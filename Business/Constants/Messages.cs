using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added to the system successfully.";
        public static string CarDeleted = "Car deleted from the system successfully.";
        public static string CarUpdated = "Car updated successfully.";
        public static string InvalidDescription = "Car name must be at least lentgh of 2!";
        public static string InvalidDailyPrice = "Daily price must be a positive value!";

        public static string MaintenanceTime = "System is under maintenance. Please try again later.";

        public static string ColorAdded = "Color added to the system successfully.";
        public static string ColorDeleted = "Color deleted from the system successfully.";
        public static string ColorUpdated = "Color updated successfully.";

        public static string BrandAdded = "Brand added to the system successfully.";
        public static string BrandDeleted = "Brand deleted from the system successfully.";
        public static string BrandUpdated = "Brand updated successfully.";

        public static string UserAdded = "User registered successfully.";
        public static string UserDeleted = "User deleted from the system successfully.";
        public static string UserUpdated = "User updated successfully.";

        public static string CustomerAdded = "Customer registered successfully.";
        public static string CustomerDeleted = "Customer deleted from the system successfully.";
        public static string CustomerUpdated = "Customer updated successfully.";
        public static string CustomershipAlreadyExist = "This customership is alreay exists!";

        public static string RentalAdded = "Car rented successfully.";
        public static string RentalDeleted = "Rental deleted from the system successfully.";
        public static string RentalUpdated = "Rental updated successfully.";
        public static string CarAlreadyRented = "Car is already rented!";

        public static string CarImageAdded = "Car image added to the system successfully.";
        public static string CarImageDeleted = "Car image deleted from the system successfully.";
        public static string CarImageUpdated = "Car image updated successfully.";

        public static string UserNotFound = "User not found!";
        public static string PasswordError = "Password error!";
        public static string SuccessfulLogin = "Logged in successfully.";

        public static string UserExists = "User exists with this email!";
    }
}
