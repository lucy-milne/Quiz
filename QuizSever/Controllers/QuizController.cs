using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace QuizSever.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public QuizController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [Route("otherQuizzes")]
        [HttpPost]
        public IActionResult GetOtherQuizzes(UserDto user)
        {
            try
            {
                var quizzes = _repository.Quiz.GetOtherQuizzes(user.Id);
                var quizzesResult = _mapper.Map<IEnumerable<QuizDto>>(quizzes).ToList();
                return Ok(quizzesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllQuestion action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("usersQuizzes")]
        [HttpPost]
        public IActionResult GetUsersQuizzes(UserDto user)
        {
            try
            {
                var quizzes = _repository.Quiz.GetUsersQuizzes(user.Id);
                var quizzesResult = _mapper.Map<IEnumerable<QuizDto>>(quizzes).ToList();
                return Ok(quizzesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUsersQuizzes action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateQuiz(QuizForCreationDto quiz)
        {
            try
            {
                var quizEntity = _mapper.Map<Quiz>(quiz);

                _repository.Quiz.CreateQuiz(quizEntity);
                _repository.Save();

                var createdOwner = _mapper.Map<QuizDto>(quizEntity);

                return Ok(createdOwner.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQuiz action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(Guid id)
        {
            try
            {
                var quiz = _repository.Quiz.GetQuizById(id);
                _repository.Quiz.DeleteQuiz(quiz);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteQuiz action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}