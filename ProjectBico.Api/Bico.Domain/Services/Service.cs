using Fatec.Domain.Repositories.Transaction;
using Fatec.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Fatec.Domain.Services
{
    public class Service : IService
    {
        public Service(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        private readonly IUnitOfWork _unitOfWork;

        protected Task<bool> SaveChangesAsync() => _unitOfWork.SaveChangesAsync();
    }
}
