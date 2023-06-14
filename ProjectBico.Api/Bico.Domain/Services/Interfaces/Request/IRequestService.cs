using System.Collections.Generic;
using System.Threading.Tasks;
using RequestEntity = Fatec.Domain.Entities.Request.Request;    

namespace Fatec.Domain.Services.Interfaces.Request
{
    public interface IRequestService
    {
        public Task<bool> CreateRequest(RequestEntity request);
        public Task<IEnumerable<RequestEntity>> GetRequests();
        public Task<RequestEntity> GetById(long id);
        public Task<bool> Approval(long id, bool action);
    }
}
