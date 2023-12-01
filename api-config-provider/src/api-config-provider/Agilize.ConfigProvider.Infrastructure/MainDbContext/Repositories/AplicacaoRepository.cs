using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.HttpExceptions;

namespace Agilize.ConfigProvider.Infrastructure.MainDbContext.Repositories;

public class AplicacaoRepository : IAplicacaoRepository
{
    public Task<IEnumerable<IAplicacao>> ObterListaDeAplicacoes(
        out int total,
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null)
    {
        throw new Http501NaoImplementadoException();
    }
}
