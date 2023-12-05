using Agilize.ConfigProvider.Domain.Configuracao;
using Agilize.ConfigProvider.Domain.MainDbContext;
using Agilize.HttpExceptions;
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

    public async Task<IEnumerable<IChave>> BuscarChaves(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool habilitado = true,
        int? skip = 0,
        int? limit = null)
    {
        return await _uow.DbConnection.QueryAsync<Chave>(
            """
            SELECT *
            FROM Chaves
            WHERE
                AppId = @p_AppId::uuid AND
                (@p_Nome IS NULL OR LOWER(Nome) ~ @p_Nome) AND
                (Habilitado = @p_Habilitado) AND
                (@p_IdTipo IS NULL OR IdTipo = @p_IdTipo) AND
                (VigenteDe IS NULL OR VigenteDe <= @p_VigenteEm::date) AND
                (VigenteAte IS NULL OR VigenteAte >= @p_VigenteEm::date)
            ORDER BY Nome
            OFFSET @p_Skip
            LIMIT @p_Limit;
            """,
            new
            {
                p_AppId = appId,
                p_Nome = nome?.ToLower(),
                p_IdTipo = idTipo,
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm,
                p_Skip = skip,
                p_Limit = limit
            });
    }

    public async Task<int> ContarChaves(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool habilitado = true)
    {
        return await _uow.DbConnection.ExecuteScalarAsync<int>(
            """
            SELECT COUNT(*)
            FROM Chaves
            WHERE
                AppId = @p_AppId::uuid AND
                (@p_Nome IS NULL OR LOWER(Nome) ~ @p_Nome) AND
                (Habilitado = @p_Habilitado) AND
                (@p_IdTipo IS NULL OR IdTipo = @p_IdTipo) AND
                (VigenteDe IS NULL OR VigenteDe <= @p_VigenteEm::date) AND
                (VigenteAte IS NULL OR VigenteAte >= @p_VigenteEm::date)
            """,
            new
            {
                p_AppId = appId,
                p_Nome = nome?.ToLower(),
                p_IdTipo = idTipo,
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm
            });
    }

    private async Task<IValor<T>> BuscarValor<T, TT>(
        int idChave,
        string tabela)
        where TT : IValor<T>
    {
        return (await _uow.DbConnection.QueryAsync<TT>(
                """
                SELECT *
                FROM ValoresNumeros
                WHERE
                    IdChave = @p_IdChave;
                """,
                new
                {
                    p_IdChave = idChave
                }))
            .SingleOrDefault<IValor<T>>()!;
    }

    public async Task<IValor<double>> BuscarValorDouble(
        int idChave)
    {
        return await BuscarValor<double, ValorDouble>(idChave, "ValoresNumeros");
    }

    public async Task<IEnumerable<IValor<double>>> BuscarValoresDouble(
        int idChave)
    {
        throw new Http501NaoImplementadoException();
    }

    public async Task<IValor<string>> BuscarValorString(
        int idChave)
    {
        throw new Http501NaoImplementadoException();
    }

    public async Task<IEnumerable<IValor<string>>> BuscarValoresString(
        int idChave)
    {
        throw new Http501NaoImplementadoException();
    }

    public async Task<IValor<bool>> BuscarValorBoolean(
        int idChave)
    {
        throw new Http501NaoImplementadoException();
    }

    public async Task<IEnumerable<IValor<bool>>> BuscarValoresBoolean(
        int idChave)
    {
        throw new Http501NaoImplementadoException();
    }

    public async Task<IValor<DateTime>> BuscarValorDateTime(
        int idChave)
    {
        throw new Http501NaoImplementadoException();
    }

    public async Task<IEnumerable<IValor<DateTime>>> BuscarValoresDateTime(
        int idChave)
    {
        throw new Http501NaoImplementadoException();
    }
}

file record Chave : IChave
{
    public int Id { get; init; }
    public Guid AppId { get; init; }
    public required string Nome { get; init; }
    public int IdTipo { get; init; }
    public bool Lista { get; init; }
    public bool PermiteNulo { get; init; }
    public int? IdChavePai { get; init; }
    public bool Habilitado { get; init; }
    public DateTime? VigenteDe { get; init; }
    public DateTime? VigenteAte { get; init; }
}

file record ValorDouble : IValor<double>
{
    public int Id { get; init; }
    public int IdChave { get; init; }
    public double Valor { get; init; }
    public bool Habilitado { get; init; }
    public DateTime? VigenteDe { get; init; }
    public DateTime? VigenteAte { get; init; }
}

file record ValorString : IValor<string>
{
    public int Id { get; init; }
    public int IdChave { get; init; }
    public required string Valor { get; init; }
    public bool Habilitado { get; init; }
    public DateTime? VigenteDe { get; init; }
    public DateTime? VigenteAte { get; init; }
}

file record ValorBoolean : IValor<bool>
{
    public int Id { get; init; }
    public int IdChave { get; init; }
    public bool Valor { get; init; }
    public bool Habilitado { get; init; }
    public DateTime? VigenteDe { get; init; }
    public DateTime? VigenteAte { get; init; }
}

file record ValorDateTime : IValor<DateTime>
{
    public int Id { get; init; }
    public int IdChave { get; init; }
    public DateTime Valor { get; init; }
    public bool Habilitado { get; init; }
    public DateTime? VigenteDe { get; init; }
    public DateTime? VigenteAte { get; init; }
}
