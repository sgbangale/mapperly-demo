using Refit;
var builder = WebApplication.CreateBuilder(args);

// Register Refit Http Client and include possible http client options like base address, default request headers, authorization jwt token etc.
builder.Services.AddRefitClient<IUserService>()
    .ConfigureHttpClient((p, client) =>
    {
        client.BaseAddress = new Uri("https://my-json-server.typicode.com/sgbangale/json-server");
        client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
    });
builder.Services.AddSingleton<UserMapper>();
var app = builder.Build();

app.MapGet("/", async (IUserService userService, UserMapper mapper) =>
{
    var data = await userService.Get();
    var userResponse = mapper.ToUserResponse(data);
    return userResponse;
});

app.MapGet("/users", async (IUserService userService, UserMapper mapper) =>
{
    var data = await userService.Get();
    var userAddresses = mapper.ToUserFullAddress(data);
    return userAddresses;
});

app.Run();
