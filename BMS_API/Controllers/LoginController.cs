using AutoMapper;
using BMS_API.Models.Domains;
using BMS_API.Models.DTO;
using BMS_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public LoginController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        

        [HttpGet("{uname}")]
        public async Task<UserDetailDTO> Get(string uname)
        {
            UserDetail userDetail = await userRepository.GetUserAsync(uname);
            UserDetailDTO userDetailDTO = mapper.Map<UserDetailDTO>(userDetail);

            return userDetailDTO;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDetailDTO value)
        {
            int role = await userRepository.ValidateUserCredAsync(value.UserName, value.Password);

            if (role == 0)
                return Ok("User");
            else if (role == 1)
                return Ok("Admin");
            else
                return NotFound("User Not Found");
            
        }

    }
}
