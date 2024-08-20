
# Mapperly Demo: Simplifying Object Mapping in C#

## Introduction

This repository contains a demo project showcasing how to use Mapperly for efficient and type-safe object mapping in C#. Mapperly is a Roslyn-based source generator that generates mapping code at compile time, offering a simple and performant alternative to traditional mapping approaches.

## Contents

- **`Models/`**: Contains the `User`, `Address`, `Company`, and `UserAddress` records.
- **`Mappers/`**: Contains the `UserMapper` class configured with Mapperly to map `User` objects to `UserAddress`.
- **`Program.cs`**: Demonstrates the usage of the generated mapper in a sample application.

## Prerequisites

- .NET SDK 6.0 or higher
- Visual Studio or any C# IDE of your choice

## Setup

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/sgbangale/mapperly-demo.git
   cd mapperly-demo
   ```

2. **Install Mapperly:**

   Ensure that Mapperly is included in your project. If not, you can add it via NuGet:

   ```bash
   dotnet add package Riok.Mapperly
   ```

## How It Works

### Step 1: Define Your Records

In the `Models/` directory, you'll find the following record definitions:

```csharp
public record Geo(string Lat, string Lng);

public record Address(string Street, string Suite, string City, string Zipcode, Geo Geo);

public record Company(string Name, string CatchPhrase, string Bs);

public record User(
    int Id,
    string Name,
    string Username,
    string Email,
    Address Address,
    string Phone,
    string Website,
    Company Company
);

public record UserAddress(string Name, string Username, string Email, string? FullAddress);
```

### Step 2: Create the Mapperly Configuration

The `UserMapper` class in the `Mappers/` directory is configured to map `User` objects to `UserAddress`:

```csharp
using Riok.Mapperly.Abstractions;

[Mapper]
public partial class UserMapper
{
    [MapProperty(nameof(User.Address), nameof(UserAddress.FullAddress))]
    private string MapFullAddress(Address address)
    {
        return $"{address.Street}, {address.Suite}, {address.City}, {address.Zipcode}";
    }

    public partial UserAddress MapToUserAddress(User user);

    // Additional method to map an array of User to an array of UserAddress
    public partial UserAddress[] MapToUserAddressArray(User[] users);
}
```

### Step 3: Run the Demo

In `Program.cs`, you can see how to use the generated mapper:

```csharp
var users = new User[]
{
    new User(
        Id: 1,
        Name: "John Doe",
        Username: "johndoe",
        Email: "johndoe@example.com",
        Address: new Address("123 Elm St", "Apt 456", "Springfield", "12345", new Geo("12.34", "56.78")),
        Phone: "123-456-7890",
        Website: "johndoe.com",
        Company: new Company("Doe Inc.", "We do it", "Consulting")
    )
    // Additional User objects can be added here
};

var userMapper = new UserMapper();
var userAddresses = userMapper.MapToUserAddressArray(users);

foreach (var userAddress in userAddresses)
{
    Console.WriteLine(userAddress.FullAddress);  // Outputs: 123 Elm St, Apt 456, Springfield, 12345
}
```

## Conclusion

Mapperly provides a clean, efficient, and type-safe way to handle object mapping in C# projects. This demo highlights how easy it is to set up and use Mapperly, reducing boilerplate code and improving performance compared to traditional mapping approaches.

## Further Exploration

- Explore the [Mapperly Documentation](https://mapperly.riok.app/docs/intro/) for more advanced features and configurations.
- Try extending the demo with more complex mappings or custom mapping logic.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

---