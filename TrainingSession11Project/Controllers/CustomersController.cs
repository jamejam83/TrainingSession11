using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingSession11Project.Models;

namespace TrainingSession11Project.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerrepository;

        public CustomersController(ICustomerRepository _customerrepository)
        {
            customerrepository = _customerrepository;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var CustomerList = customerrepository.GetAllCustomers();
            return View(CustomerList);
        }

       // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerrepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer,bool Approve)
        {
            if (Approve)
            {
                int newid = customerrepository.AddCustomer(customer);
                return RedirectToAction("index");
               
            }
            return View();
        }

      //  GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerrepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int CustomerId ,Customer customer, bool Approve)
        {
            if (Approve)
            {
                if (CustomerId != customer.CustomerId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {

                    Customer cm = customerrepository.GetCustomer(CustomerId);
                    if (cm == null)
                    {
                        return NotFound();
                    }
                    if (customerrepository.UpdateCustomer(customer))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(customer);
        }

        //  GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerrepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = customerrepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            else if (customerrepository.DeleteCustomer(customer))
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customers.Any(e => e.CustomerId == id);
        //}
    }
}
