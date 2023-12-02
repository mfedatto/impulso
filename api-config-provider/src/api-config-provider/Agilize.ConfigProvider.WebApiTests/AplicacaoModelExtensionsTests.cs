using Agilize.ConfigProvider.Domain.Aplicacao;
using Agilize.ConfigProvider.WebApi.Controllers.Aplicacao;

namespace Agilize.ConfigProvider.WebApiTests;

public class AplicacaoModelExtensionsTests
{
    [Test]
    public void ToGetResponseModel_ShouldMapPropertiesCorrectly()
    {
        // Arrange
        IAplicacao aplicacao = new Aplicacao
        {
            AppId = Guid.NewGuid(),
            Nome = "TesteApp",
            Sigla = "TA",
            Aka = "AppAlias",
            Habilitado = true,
            VigenteDe = DateTime.Now,
            VigenteAte = DateTime.Now.AddYears(1)
        };

        // Act
        GetAplicacoesResponseModel result = aplicacao.ToGetResponseModel();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.AppId, Is.EqualTo(aplicacao.AppId));
            Assert.That(result.Nome, Is.EqualTo(aplicacao.Nome));
            Assert.That(result.Sigla, Is.EqualTo(aplicacao.Sigla));
            Assert.That(result.Aka, Is.EqualTo(aplicacao.Aka));
            Assert.That(result.Habilitado, Is.EqualTo(aplicacao.Habilitado));
            Assert.That(result.VigenteDe, Is.EqualTo(aplicacao.VigenteDe));
            Assert.That(result.VigenteAte, Is.EqualTo(aplicacao.VigenteAte));
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
