using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingSession11Project.Models
{
    public interface ICustomerRepository
    {
        int AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int? Id);

        bool DeleteCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);
    }
}
