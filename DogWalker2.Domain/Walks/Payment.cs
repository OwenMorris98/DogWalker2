using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace DogWalker2.Domain.Walks
{


    public class Payment
    {
        public int PaymentID { get; set; }
        public Customer Customer { get; set; }
        public Walker Walker { get; set; }
        public Walk? Walk { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public Payment(int paymentID, Customer customer, Walker walker, Walk? walk, decimal amount, DateTime paymentDate, string paymentMethod)
        {
            PaymentID = paymentID;
            Customer = customer;
            Walker = walker;
            Walk = walk;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
        }
        public Payment() { }
    }

}
