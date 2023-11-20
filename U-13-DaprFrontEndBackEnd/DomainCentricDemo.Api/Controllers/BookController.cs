using AutoMapper;
using Dapr;
using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Dapr.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DomainCentricDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookQuery _queryService;
        private readonly IBookCommand _command;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookQuery queryService, IBookCommand command, IMapper mapper, ILogger<BookController> logger)
        {
            _queryService = queryService;
            _command = command;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<Book>
        [HttpGet]
        public IEnumerable<BookDto> Get()
        {
            return _queryService.GetAll();
        }

        // GET api/<Book>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _queryService.Get(id);
            if (result is null) return NotFound();
            
            return Ok(result);
        }

        // POST api/<Book>
        // [Topic("pubsub", "books", "deadletters", false)]
        [HttpPost]
        public void Post([FromBody] BookDto book)
        {
            var commandDto = _mapper.Map<BookCreateCommandRequestDto>(book);
            _command.Create(commandDto);
        }

        // PUT api/<Book>
        [HttpPut]
        public void Put([FromBody] BookDto book)
        {
            var commandDto = _mapper.Map<BookUpdateRequestDto>(book);
            _command.Update(commandDto);
        }

        // DELETE api/<Book>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _command.Delete(id);
        }

        [Topic("pubsub", "deadletters")]
        [Route("deadletters")]
        [HttpPost()]
        public ActionResult HandleDeadLetter(object message)
        {
            _logger.LogError("The service was not able to handle a CollectFine message.");

            try
            {
                var messageJson = JsonSerializer.Serialize(message);
                _logger.LogInformation($"Unhandled message content: {messageJson}");
            }
            catch 
            {
                _logger.LogError("Unhandled message's payload could not be deserialized.");
            }

            return Ok();
        }
    }
}
