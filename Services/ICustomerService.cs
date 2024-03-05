using Microsoft.EntityFrameworkCore;
using WheelzyTest.Model;

namespace WheelzyTest.Services
{
    public interface ICustomerService
    {

        public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices);

        public List<Customer> GetCustomersData();
    }
}
