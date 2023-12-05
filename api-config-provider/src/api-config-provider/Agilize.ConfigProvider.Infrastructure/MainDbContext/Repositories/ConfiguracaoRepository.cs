using Agilize.ConfigProvider.Domain.Configuracao;
using Agilize.ConfigProvider.Domain.MainDbContext;
using Dapper;

namespace Agilize.ConfigProvider.Infrastructure.MainDbContext.Repositories;

public class ConfiguracaoRepository : IConfiguracaoRepository
{
    private readonly IUnitOfWork _uow;

    public ConfiguracaoRepository(
        IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<IConfiguracaoChaveValor<dynamic>>> BuscarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null,
        int? skip = 0,
        int? limit = null)
    {
        return await _uow.DbConnection.QueryAsync<IConfiguracaoChaveValor<dynamic>>(
            """
            SELECT *
            FROM Chaves
            WHERE
                AppId = @p_AppId::uuid AND
                (@p_Nome IS NULL OR LOWER(Nome) ~ @p_Nome) AND
                (@p_Habilitado IS NULL OR Habilitado = @p_Habilitado) AND
                (VigenteDe IS NULL OR VigenteDe <= @p_VigenteEm::date) AND
                (VigenteAte IS NULL OR VigenteAte >= @p_VigenteEm::date))
            ORDER BY Nome
            OFFSET @p_Skip
            LIMIT @p_Limit;
            """,
            new
            {
                p_AppId = appId,
                p_Nome = nome?.ToLower(),
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm,
                p_Skip = skip,
                p_Limit = limit
            });
    }

    public async Task<int> ContarConfiguracoes(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool? habilitado = null)
    {
        return await _uow.DbConnection.ExecuteScalarAsync<int>(
            """
            SELECT COUNT(*)
            FROM Chaves
            WHERE
                AppId = @p_AppId::uuid AND
                (@p_Nome IS NULL OR LOWER(Nome) ~ @p_Nome) AND
                (@p_Habilitado IS NULL OR Habilitado = @p_Habilitado) AND
                (VigenteDe IS NULL OR VigenteDe <= @p_VigenteEm::date) AND
                (VigenteAte IS NULL OR VigenteAte >= @p_VigenteEm::date))
            """,
            new
            {
                p_AppId = appId,
                p_Nome = nome?.ToLower(),
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm
            });
    }
}
