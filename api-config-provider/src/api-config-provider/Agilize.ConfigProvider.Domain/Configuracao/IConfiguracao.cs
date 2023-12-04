using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.Domain.Tipo;

namespace Agilize.ConfigProvider.Domain.Configuracao;

public interface IConfiguracao
{
    int Id { get; }
    IAplicacao Aplicacao { get; }
    string Nome { get; }
    ITipo Tipo { get; }
    bool Lista { get; }
    bool PermiteNulo { get; }
    IConfiguracao Pai { get; }
    bool Habilitado { get; }
    DateTime? VigenteDe { get; }
    DateTime? VigenteAte { get; }
}
