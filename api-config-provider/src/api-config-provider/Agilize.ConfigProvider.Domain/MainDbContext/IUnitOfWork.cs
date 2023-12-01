using System.Data;

namespace Agilize.ConfigProvider.Domain.MainDbContext;

public interface IUnitOfWork
{
    IDbConnection DbConnection { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
}
