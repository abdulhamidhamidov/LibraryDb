using Npgsql;

namespace Infrostruckture.Datacontext;

public interface IDapperContext
{
    NpgsqlConnection Connection();
}