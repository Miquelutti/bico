using Fatec.Domain.Exceptions;
using Fatec.Domain.Repositories.Interfaces;
using Fatec.Domain.Repositories.Transaction;
using Fatec.Domain.Services.Interfaces.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RequestEntity = Fatec.Domain.Entities.Request.Request;
using ContractEntity = Fatec.Domain.Entities.Contract.Contract;
using static System.Net.Mime.MediaTypeNames;

namespace Fatec.Domain.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;

        private const int NEW_STATUS = 1;
        private const int IN_PROGRESS_STATUS = 1;

        public RequestService(IRequestRepository requestRepository, IUnitOfWork unitOfWork)
        {
            _requestRepository = requestRepository ?? throw new ArgumentNullException(nameof(requestRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> CreateRequest(RequestEntity request) 
        {
            request.RequestStatusId = NEW_STATUS;
            _requestRepository.Add(request);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<RequestEntity>> GetRequests()
        {
            return await _requestRepository.GetAllAsync();
        }

        public async Task<RequestEntity> GetById(long id)
        {
            return await _requestRepository.FindById(id);
        }

        public async Task<bool> Approval(long id, bool action)
        {
            var request = await _requestRepository.FindById(id);
            
            if (request == null)
                throw new NotFoundException("REQUEST NOT FOUND!");

            var newContract = CreateContract(request);

            _contractRepository.Add(newContract);

            return await _unitOfWork.SaveChangesAsync();
        }

        private ContractEntity CreateContract(RequestEntity request)
        {
            return new ContractEntity()
            {
                RequestId = request.Id,
                ContractingUserId = request.ContractingUserId,
                Description = request.Description,
                Price = CalcPrice(request, request.StartTime, request.EndTime),
                JobId = request.JobId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalDays = (request.EndDate - request.StartDate).Value.Days,
                ContractStatusId = IN_PROGRESS_STATUS
            };
        }

        private double CalcPrice(RequestEntity request, TimeSpan startTime, TimeSpan endTime)
        {
            var validateHour = startTime < endTime;

            var result = validateHour ? (endTime - startTime).Hours : CalcHoursWhenStartTimeHigher(startTime, endTime);

            return result * request.Job.PriceTime;
        }

        private int CalcHoursWhenStartTimeHigher(TimeSpan startTime, TimeSpan endTime)
        {
            var startTimeDay = new DateTime(2000, 1, 1, startTime.Hours, startTime.Minutes, startTime.Seconds);
            var endTimeDay = new DateTime(2000, 1, 2, endTime.Hours, endTime.Minutes, endTime.Seconds);

            return (endTimeDay - startTimeDay).Hours;
        }
    }
}
