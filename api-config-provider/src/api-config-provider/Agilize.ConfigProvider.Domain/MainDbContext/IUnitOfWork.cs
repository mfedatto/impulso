using System.Data;

namespace Agilize.ConfigProvider.Domain.MainDbContext;

public interface IUnitOfWork
{
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; }

    void OpenConnection();
    void BeginTransaction();
    void Commit();
    void Rollback();
}
