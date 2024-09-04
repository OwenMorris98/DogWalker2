namespace DogWalker2.Client.Models
{

    public class CustomerRoot
    {
        public List<Customer> customers { get; set; }
    }
    public class Customer
    {
        public string id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
    }

    public record PutCustomerRequest(string firstName, string lastName);

    public class Dogs
    {
        public string name { get; set; }

        public string breed { get; set; }

        public int age { get; set; }

        public string? notes { get; set; }


     
    }
}
