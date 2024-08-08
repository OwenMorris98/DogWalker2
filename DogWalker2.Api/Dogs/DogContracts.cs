namespace DogWalker2.Api.Dogs
{
   public record PostDogRequest(string name, string breed, int age, string? notes);
}
