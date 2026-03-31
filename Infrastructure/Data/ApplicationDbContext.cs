using Npgsql;

namespace Infrastructure.Data;

public class ApplicationDbContext
{
    private readonly string connString = "Host=localhost;Port=5432;Database=Instagram;Username=postgres;Password=america";

    public NpgsqlConnection Connect()=> new NpgsqlConnection(connString);
}
