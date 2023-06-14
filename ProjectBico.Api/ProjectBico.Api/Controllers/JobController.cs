using AutoMapper;
using Fatec.Domain.Entities.Job;
using Fatec.Domain.Services.Interfaces.Job;
using Fatec.Domain.Services.Interfaces.JobCategory;
using Fatec.Domain.Services.JobCategory;
using Microsoft.AspNetCore.Mvc;
using ProjectFatec.WebApi.Models.Request;
using ProjectFatec.WebApi.Models.Response.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjectFatec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IJobCategoryService _jobCategoryService;
        private readonly IMapper _mapper;

        public JobController(IMapper mapper, IJobService jobService, IJobCategoryService jobCategoryService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jobService = jobService ?? throw new ArgumentNullException(nameof(jobService));
            _jobCategoryService = jobCategoryService ?? throw new ArgumentNullException(nameof(jobCategoryService));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateJob([FromBody] JobRequest request)
        {
            var job = _mapper.Map<Job>(request);

            var response = await _jobService.CreateJob(job);

            if(!response)
                return BadRequest();
                
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(JobViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = _mapper.Map<IEnumerable<JobViewModel>>(await _jobService.GetJobs());

            if (jobs == null)
                return BadRequest();

            return Ok(jobs);
        }

        [HttpGet]
        [ProducesResponseType(typeof(JobDetailsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}")]
        public async Task<IActionResult> GetJobById(long id)
        {
            var job = _mapper.Map<JobDetailsViewModel>(await _jobService.GetJobById(id));

            if (job == null)
                return BadRequest();

            return Ok(job);
        }

        [HttpGet]
        [ProducesResponseType(typeof(JobCategoryViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("jobCategory")]
        public async Task<IActionResult> GetAllJobsCategories() 
        {
            var jobCategories = _mapper.Map<IEnumerable<JobCategoryViewModel>>(await _jobCategoryService.GetJobsCategories());

            if (jobCategories == null)
                return BadRequest();

            return Ok(jobCategories);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Route("{id}/activation/{activationId}")]
        public async Task<IActionResult> ChangeJobActivation(long id, int activationId)
        {
            var job = await _jobService.ChangeActivation(id, activationId);

            if (!job)
                return BadRequest();

            return Ok();
        }
    }
}
