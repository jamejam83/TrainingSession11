using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingSession11Project.Models
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly MyDBContext mycontext;

        public CustomerRepository(MyDBContext _context )
        {
            mycontext = _context;
        }

        public int AddCustomer(Customer customer)
        {
            mycontext.Customers.Add(customer);
            mycontext.SaveChanges();
            return customer.CustomerId;
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                mycontext.Customers.Remove(customer);
                mycontext.SaveChanges();
                return true;
            }
            catch{ return false; }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return mycontext.Customers.ToList();
        }

        public Customer GetCustomer(int? Id)
        {
            if (Id != null)
                return mycontext.Customers.Find(Id);
            else return null;
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                Customer cm = GetCustomer(customer.CustomerId);
                cm.FName = customer.FName;
                cm.LName = customer.LName;
                cm.UserName = customer.UserName;
                cm.Email  = customer.Email;
                cm.Mobile = customer.Mobile;
                cm.Tel = customer.Tel;
                cm.CodeMelli = customer.CodeMelli;
                cm.SHNumber = customer.SHNumber;
                cm.PostalCode = customer.PostalCode;
                cm.Address = customer.Address;
                cm.UserPanelType = customer.UserPanelType;
                cm.Status = customer.Status;
                cm.CompanyName = customer.CompanyName;
                cm.CompanyRegisterCode = customer.CompanyRegisterCode;
                cm.CompanyEconomicCode = customer.CompanyEconomicCode;
                cm.IntroMethod = customer.IntroMethod;
                mycontext.Customers.Update(cm);
                mycontext.SaveChanges();
                return true;
            }
            catch(Exception ex) { return false; }
        }
    }
}
