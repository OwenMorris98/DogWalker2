namespace DogWalker2.Api.Customers
{
    public record CreateUserRequest(string email, string password);

    public record PutCustomerRequest(string firstName, string lastName);
}
