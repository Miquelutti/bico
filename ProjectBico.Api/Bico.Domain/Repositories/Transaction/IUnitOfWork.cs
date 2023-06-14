using System.Threading.Tasks;

namespace Fatec.Domain.Repositories.Transaction
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
