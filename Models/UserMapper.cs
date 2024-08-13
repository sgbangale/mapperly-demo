using Riok.Mapperly.Abstractions;

[Mapper]
public partial class UserMapper
{

    public partial UserResponse[] ToUserResponse(User[] users);

    public partial UserAddress[] ToUserFullAddress(User[] users);

    [MapProperty(nameof(User.Address), nameof(UserAddress.FullAddress))]
    public partial UserAddress ToUserFullAddress(User users);

    [MapProperty(nameof(User.Address), nameof(UserAddress.FullAddress))]
    private string MapFullAddress(Address address)
    {
        if (address == null) return string.Empty;
        // Concatenate the fields to create the full address
        return $"{address.Street}, {address.Suite}, {address.City}, {address.Zipcode}";
    }

}