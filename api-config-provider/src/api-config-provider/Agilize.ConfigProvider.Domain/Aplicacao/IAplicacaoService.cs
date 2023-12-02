namespace Agilize.ConfigProvider.Domain.Aplicacao;

public interface IAplicacaoService
{
    Task<IEnumerable<IAplicacao>> ObterListaDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null);
    Task<int> ObterTotalDeAplicacoes(
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null);
    Task<IAplicacao> IncluirAplicacao(IAplicacao aplicacao);
}
