namespace DogWalker2.Application.DTOs.Customers
{
    public class AddCustomerDTO
    {
        public string first_name { get; set; }

        public string last_name { get; set; }

        public string? address { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }

    }
}
