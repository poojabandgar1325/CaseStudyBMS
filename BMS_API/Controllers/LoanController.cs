using AutoMapper;
using BMS_API.Models.Domains;
using BMS_API.Models.DTO;
using BMS_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BMS_API.Controllers
{
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanRepositry userRepository;

        private readonly IMapper mapper;

        public LoanController(ILoanRepositry userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Post([FromBody] LoanDetail value)
        {
            bool response = await userRepository.SaveLoanDeatilAsync(value);

            if (response)
                return Ok("Added Succesfully");

            return BadRequest("Something Went Wrong");

        }

        [HttpPut]
        [Route("api/[controller]/statusUpdate/{userName}")]

        public async Task<IActionResult> Put(int loandId, string status)
        {
            //convert DTO to Domain model
            var user = new Models.Domains.LoanDetail()
            {
                Status = status,
            };

            //Update User using repository
            bool response = await userRepository.UpdateStatusAsync(loandId, status);


            //if null then notfound

            if (response)
                return Ok("Updated Successfully ");

            return BadRequest("Something went wrong..!");


        }

        [Route("api/[controller]/{loanId}")]
        [HttpGet]
        public async Task<LoanDetailDTO> Get(int loanId)
        {
            LoanDetail loanDetail = await userRepository.GetLoanAsync(loanId);
            LoanDetailDTO loanDetailDTO = mapper.Map<LoanDetailDTO>(loanDetail);

            return loanDetailDTO;
        }

       
        [Route("api/[controller]/all")]
        [HttpGet]
        public async Task<List<LoanDetailDTO>> Get()
        {
            List<LoanDetail> loanDetails = await userRepository.GetAllAsync();
            List<LoanDetailDTO> loanDetailDTO = mapper.Map<List<LoanDetailDTO>>(loanDetails);

            return loanDetailDTO;
        }

       
        [Route("api/[controller]/all/{userName}")]
        [HttpGet]
        public async Task<List<LoanDetailDTO>> Get(string userName)
        {
            List<LoanDetail> loanDetails = await userRepository.GetAllLoanAsync(userName);
            List<LoanDetailDTO> loanDetailDTO = mapper.Map<List<LoanDetailDTO>>(loanDetails);

            return loanDetailDTO;
        }

        
        

        
    }
}