using Agilize.ConfigProvider.CrossCutting.CompositionRoot;
using Agilize.ConfigProvider.WebApi.Extensions;

WebApplication.CreateBuilder(args)
    .AddCompositionRoot()
    .Build()
    .Configure()
    .Run();
