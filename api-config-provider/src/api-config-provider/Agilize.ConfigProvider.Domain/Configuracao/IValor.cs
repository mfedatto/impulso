namespace Agilize.ConfigProvider.Domain.Configuracao;

public interface IValor<out T>
{
    int Id { get; }
    int IdChave { get; }
    T Valor { get; }
    bool Habilitado { get; }
    DateTime? VigenteDe { get; }
    DateTime? VigenteAte { get; }
}
