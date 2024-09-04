namespace DogWalker2.Api.Customers
{
    public record CreateUserRequest(string email, string password);

    public record GetCustomerResponse(string first_name, string last_name);

    public record PutCustomerRequest(string firstName, string lastName);
}
