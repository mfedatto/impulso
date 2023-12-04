using Agilize.ConfigProvider.Domain.MainDbContext;
using Agilize.ConfigProvider.Domain.Tipo;
using Dapper;

namespace Agilize.ConfigProvider.Infrastructure.MainDbContext.Repositories;

public class TipoRepository : ITipoRepository
{
    private readonly IUnitOfWork _uow;

    public TipoRepository(
        IUnitOfWork uow)
    {
        _uow = uow;
    }
    
    public async Task<IEnumerable<ITipo>> BuscarTipos(
        int? id = null,
        string? nome = null,
        bool? habilitado = null,
        int? skip = 0,
        int? limit = null)
    {
        return await _uow.DbConnection.QueryAsync<Tipo>(
            """
                SELECT *
                FROM Tipos
                WHERE
                    (@p_Id IS NULL OR Id = @p_Id) AND
                    (@p_Nome IS NULL OR LOWER(Nome) ~ @p_Nome) AND
                    (@p_Habilitado IS NULL OR Habilitado = @p_Habilitado)
                ORDER BY Nome
                OFFSET @p_Skip
                LIMIT @p_Limit;
            """,
            new
            {
                p_Id = id,
                p_Nome = nome?.ToLower(),
                p_Habilitado = habilitado,
                p_Skip = skip,
                p_Limit = limit
            });
    }

    public async Task<int> ContarTipos(
        int? id = null,
        string? nome = null,
        bool? habilitado = null)
    {
        return await _uow.DbConnection.ExecuteScalarAsync<int>(
            """
                SELECT COUNT(*)
                FROM Tipos
                WHERE
                    (@p_Id IS NULL OR Id = @p_Id) AND
                    (@p_Nome IS NULL OR LOWER(Nome) ~ @p_Nome) AND
                    (@p_Habilitado IS NULL OR Habilitado = @p_Habilitado);
            """,
            new
            {
                p_Id = id,
                p_Nome = nome?.ToLower(),
                p_Habilitado = habilitado
            });
    }
    
    public async Task<ITipo?> BuscarTipo(int id)
    {
        return (await _uow.DbConnection.QueryAsync<Tipo>(
            """
                SELECT *
                FROM Tipos
                WHERE
                    Id = @p_Id
                ORDER BY Nome
                OFFSET @p_Skip
                LIMIT @p_Limit;
            """,
            new
            {
                p_Id = id
            }))
            .SingleOrDefault<ITipo>();
    }
}

file record Tipo : ITipo
{
    public int Id { get; init; }
    public required string Nome { get; init; }
    public bool Habilitado { get; init; }
}
