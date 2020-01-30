using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuizSever.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public UserController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [Route("getuser")]
        public IActionResult GetUser(UserDto user)
        {
            try
            {
                var userFromDb = _repository.User.GetUser(user.Id);
                if (user.Password != userFromDb.Password) {
                    return StatusCode(401, "Incorrect Password");
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(401, "User not found");
            }
        }

        [Route("createuser")]
        [HttpPost]
        public IActionResult CreateUser( UserDto user)
        {
            try
            {
                var userEntity = _mapper.Map<User>(user);

                _repository.User.CreateUser(userEntity);
                _repository.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}