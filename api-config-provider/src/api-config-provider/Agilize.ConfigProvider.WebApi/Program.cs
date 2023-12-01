using Agilize.ConfigProvider.CrossCutting.CompositionRoot;

WebApplication.CreateBuilder(args)
    .AddCompositionRoot()
    .Build()
    .ConfigureApp()
    .Run();
