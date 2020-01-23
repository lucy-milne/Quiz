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
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private ILoggerManager _logger;

        public QuestionController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            try
            {
                var questions = _repository.Question.GetAllQuestions();
                var questionsResult = _mapper.Map<IEnumerable<QuestionDto>>(questions).ToList();
                return Ok(questionsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllQuestions action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionsForQuiz(Guid id)
        {
            try
            {
                var questions = _repository.Question.GetQuestionsForQuiz(id);
                var questionsResult = _mapper.Map<IEnumerable<QuestionDto>>(questions).ToList();
                return Ok(questionsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuestionsForQuiz action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody]QuestionForCreationsDto question)
        {
            try
            {
                var questionEntity = _mapper.Map<Questions>(question);

                _repository.Question.CreateQuestion(questionEntity);
                _repository.Save();

                var createdQuestion = _mapper.Map<QuestionDto>(questionEntity);
                Console.WriteLine(createdQuestion);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQuestion action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(Guid id)
        {
            try
            {
                var question = _repository.Question.GetQuestionById(id);
                _repository.Question.DeleteQuestion(question);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteQuestions action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}