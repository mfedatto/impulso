namespace Agilize.ConfigProvider.Domain.MainDbContext;

public interface IUnitOfWork
{
    IDbContext DbContext { get; }
    void BeginTransaction();
    void Commit();
    void Rollback();
    void Dispose();
}
