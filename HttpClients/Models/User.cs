public record Geo(
    string Lat,
    string Lng
);

public record Address(
    string Street,
    string Suite,
    string City,
    string Zipcode,
    Geo Geo
);

public record Company(
    string Name,
    string CatchPhrase,
    string Bs
);

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