using Agilize.ConfigProvider.Domain.Wrappers;

namespace Agilize.ConfigProvider.Domain.Aplicacao;

public interface IAplicacaoApplication
{
    Task<PagedListWrapper<IAplicacao>> ObterListaDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null);
}
