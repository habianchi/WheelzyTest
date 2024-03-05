using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WheelzyTest.Model;
using WheelzyTest.Model.EF;

namespace WheelzyTest.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly WheelzyTestContext dbContext;

        public CustomerService(WheelzyTestContext context)
        {
            dbContext = context;
        }

        public List<Customer> GetCustomersData()
        { 
            return dbContext.Customers.ToList();
        }
        public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
        {
            var customersToUpdate = invoices.GroupBy(inv => inv.CustomerId).Select(g => new { Id = g.Key, Total = g.Sum(inv => inv.Total) });

            foreach (var customerToUpdate in customersToUpdate)
            {
                var customer = dbContext.Customers.Find(customerToUpdate.Id);

                if (customer != null)
                {
                    customer.Balance += customerToUpdate.Total;
                }
            }

           dbContext.SaveChanges();
        }


    }
}
