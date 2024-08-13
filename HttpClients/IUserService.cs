using Refit;
public interface IUserService
{
    [Get("/users")]
    Task<User[]> Get();
}