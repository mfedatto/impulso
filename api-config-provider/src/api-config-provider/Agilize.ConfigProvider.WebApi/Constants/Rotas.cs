namespace Agilize.ConfigProvider.WebApi.Constants;

public static class Rotas
{
    public const string Aplicacoes = "aplicacoes";
    public const string AplicacoesGetAplicacoes = "";
    public const string AplicacoesPostAplicacao = "";
    public const string AplicacoesGetAplicacao = $"{{{ArgumentosNomeados.AppId}}}";
    public const string AplicacoesPutAplicacao = $"{{{ArgumentosNomeados.AppId}}}";
    public const string AplicacoesDeleteAplicacao = $"{{{ArgumentosNomeados.AppId}}}";
    public const string AplicacoesHeadAplicacao = $"{{{ArgumentosNomeados.AppId}}}";
    public const string Tipos = "tipos";
    public const string TiposGetTipos = "";
    public const string TiposGetTipo = $"{{{ArgumentosNomeados.Id}}}";
    public const string Configuracoes = $"{Aplicacoes}/{{{ArgumentosNomeados.AppId}}}/configuracoes";
    public const string ConfiguracoesGetConfiguracoes = "";
}
