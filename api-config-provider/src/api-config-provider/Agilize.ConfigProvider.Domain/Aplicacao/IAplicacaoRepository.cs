namespace Agilize.ConfigProvider.Domain.Aplicacao;

public interface IAplicacaoRepository
{
    Task<IEnumerable<IAplicacao>> ObterListaDeAplicacoes(
        out int total,
        string? appId = null,
        string? nome = null,
        string? sigla = null,
        string? aka = null,
        bool? habilitado = null,
        DateTime? vigenteEm = null,
        int? skip = 0,
        int? limit = null);
}
