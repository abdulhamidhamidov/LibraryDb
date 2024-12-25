using Npgsql;

namespace Infrostruckture.Datacontext;

public class DapperContext: IDapperContext
{
    public const string connectionString = "Server=localhost;Port=5432;Database=LibrarySystemDb;Username=postgres;Password=12345;";
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}