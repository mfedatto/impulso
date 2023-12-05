namespace Agilize.ConfigProvider.Domain.Configuracao;

public interface IConfiguracaoRepository
{
    Task<IEnumerable<IChave>> BuscarChaves(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool habilitado = true,
        int? skip = 0,
        int? limit = null);
    Task<int> ContarChaves(
        Guid appId,
        DateTime vigenteEm,
        int? idTipo = null,
        string? nome = null,
        bool habilitado = true);
    Task<IValor<double>> BuscarValorDouble(
        int idChave);
    Task<IEnumerable<IValor<double>>> BuscarValoresDouble(
        int idChave);
    Task<IValor<string>> BuscarValorString(
        int idChave);
    Task<IEnumerable<IValor<string>>> BuscarValoresString(
        int idChave);
    Task<IValor<bool>> BuscarValorBoolean(
        int idChave);
    Task<IEnumerable<IValor<bool>>> BuscarValoresBoolean(
        int idChave);
    Task<IValor<DateTime>> BuscarValorDateTime(
        int idChave);
    Task<IEnumerable<IValor<DateTime>>> BuscarValoresDateTime(
        int idChave);
}
