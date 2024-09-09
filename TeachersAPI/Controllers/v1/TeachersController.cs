using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TeachersAPI.Application.ViewModel;
using TeachersAPI.Domain.Model;
using TeachersAPI.Infrastructure.Interface;

namespace TeachersAPI.Controllers.v1
{
    [ApiController]
    [Route("api/vi/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersRepository _repository;

        public TeachersController(ITeachersRepository teachersRepository)
        { 
            _repository = teachersRepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var teachers = _repository.GetAll();
            return Ok(teachers);
        }

        [HttpPost]
        public IActionResult Add([FromForm] TeachersView teachersView) 
        { 
            var teachers = new Teachers(teachersView.name, teachersView.age);
            _repository.Add(teachers);
            return Ok(teachers);
        }

        [HttpPut]
        [Route("id")]
        public IActionResult Update(Guid id, [FromForm] TeachersView teachersView) 
        {
            var teachersId = _repository.GetById(id);
            teachersId.Up(teachersView.name, teachersView.age);
            _repository.Update(teachersId);
            return Ok(teachersId);
        }
        [HttpDelete]
        public IActionResult Delete(string name) 
        {
            _repository.Delete(name);
            return Ok();
        }
    }
}
