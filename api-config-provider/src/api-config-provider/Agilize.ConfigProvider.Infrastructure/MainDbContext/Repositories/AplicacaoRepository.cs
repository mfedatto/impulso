using System.Data;
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
            "fn_BuscarAplicacoes",
            new
            {
                p_AppId = appId,
                p_Nome = nome,
                p_Sigla = sigla,
                p_Aka = aka,
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm,
                p_Skip = skip,
                p_Limit = limit
            },
            commandType: CommandType.StoredProcedure);
    }
    
    public async Task<int> ObterTotalDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null)
    {
        return await _uow.DbConnection.ExecuteAsync(
            "fn_BuscarAplicacoes",
            new
            {
                p_AppId = appId,
                p_Nome = nome,
                p_Sigla = sigla,
                p_Aka = aka,
                p_Habilitado = habilitado,
                p_VigenteEm = vigenteEm
            },
            commandType: CommandType.StoredProcedure);
    }
}

file record Aplicacao : IAplicacao
{
    public Guid AppId { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    public string? Aka { get; set; }
    public bool Habilitado { get; set; }
    public DateTime VigenteDe { get; set; }
    public DateTime VigenteAte { get; set; }
}
