using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.MainDbContext;
using Dapper;

namespace Agilize.ConfigProvider.Infrastructure.MainDbContext.Repositories;

public class AplicacaoRepository : IAplicacaoRepository
{
    private readonly IUnitOfWork _uow;
    
    public AplicacaoRepository(IUnitOfWork uow)
    {
        _uow = uow;
    }
    
    public async Task<IEnumerable<IAplicacao>> ObterListaDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null)
    {
        return await _uow.DbConnection.QueryAsync<Aplicacao>(
            """
                SELECT *
                FROM Aplicacoes
                WHERE
                    (@p_AppId = '00000000-0000-0000-0000-000000000000' OR AppId = @p_AppId::uuid) AND
                    (@p_Nome IS NULL OR Nome = @p_Nome) AND
                    (@p_Sigla IS NULL OR Sigla = @p_Sigla) AND
                    (@p_Aka IS NULL OR Aka = @p_Aka) AND
                    (@p_Habilitado IS NULL OR Habilitado = @p_Habilitado) AND
                    (@p_VigenteEm IS NULL OR (VigenteDe IS NULL OR VigenteDe <= @p_VigenteEm::date) AND (VigenteAte IS NULL OR VigenteAte >= @p_VigenteEm::date))
                ORDER BY Nome
                OFFSET @p_Skip
                LIMIT @p_Limit;
            """,
            new
            {
                p_AppId = appId,
                p_Nome = nome,
                p_Sigla = sigla,
                p_Aka = aka,
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm?.ToString("yyyy-MM-dd HH:mm:ss"),
                p_Skip = skip,
                p_Limit = limit
            });
    }
    
    public async Task<int> ObterTotalDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null)
    {
        return await _uow.DbConnection.ExecuteScalarAsync<int>(
            """
                SELECT *
                FROM Aplicacoes
                WHERE
                    (@p_AppId = '00000000-0000-0000-0000-000000000000' OR AppId = @p_AppId::uuid) AND
                    (@p_Nome IS NULL OR Nome = @p_Nome) AND
                    (@p_Sigla IS NULL OR Sigla = @p_Sigla) AND
                    (@p_Aka IS NULL OR Aka = @p_Aka) AND
                    (@p_Habilitado IS NULL OR Habilitado = @p_Habilitado) AND
                    (@p_VigenteEm IS NULL OR (VigenteDe IS NULL OR VigenteDe <= @p_VigenteEm::date) AND (VigenteAte IS NULL OR VigenteAte >= @p_VigenteEm::date))
                ORDER BY Nome;
            """,
            new
            {
                p_AppId = appId ?? Guid.Empty.ToString(),
                p_Nome = nome,
                p_Sigla = sigla,
                p_Aka = aka,
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm?.ToString("yyyy-MM-dd HH:mm:ss")
            });
    }
}

file record Aplicacao : IAplicacao
{
    public Guid AppId { get; set; }
    public required string Nome { get; set; }
    public required string Sigla { get; set; }
    public string? Aka { get; set; }
    public bool Habilitado { get; set; }
    public DateTime VigenteDe { get; set; }
    public DateTime VigenteAte { get; set; }
}
