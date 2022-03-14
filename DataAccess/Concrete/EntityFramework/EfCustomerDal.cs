using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public Customer GetCustomerByID(int id)
        {
            return Get(c => c.Id == id);
        }

        public List<CustomerDetailDto> getCustomerDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 CustomerEmail = u.Email,
                                 CompanyName = c.CompanyName,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName
                             };

                return result.ToList();
            }
        }

        public List<Customer> GetCustomersByCompany(string company)
        {
            return GetAll(c => c.CompanyName == company);
        }
    }
}
