using Application.DTOs;
using Application.Intrfraces;
using AutoMapper;
using Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IGenericServices<TasK> _genericServices;
        private readonly IMapper _mapper;
        public TaskController(IGenericServices<TasK> genericServices, IMapper mapper) { 
         
            _genericServices = genericServices;
            _mapper = mapper;
        
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var task = await _genericServices.GetAsync(id, t => t.AssignedUser);  

            if (task == null) {
                return NotFound();

             }
            return Ok(task);

    }
        [HttpGet]
       
        public async Task<IActionResult> GetAll()
        {
            var Tasks = await _genericServices.GetAllAsync(t=>t.AssignedUser);
                if(Tasks == null)
            {
                return NotFound();
            }
                return Ok(Tasks);
        }
          
        [HttpPost]

        public async Task<IActionResult> Post(TasKDTO tasKDTO)
        {
          var task =  _mapper.Map<TasK>(tasKDTO);
            var succes = await _genericServices.PostAsync(task);

            if(succes) {
                return CreatedAtAction(nameof(Get), new { id = task.Id }, tasKDTO); ;

        }
            else
            {
                return BadRequest("Task could not be added.");
            }
          

        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, TasKDTO tasKDTO)
        {
            if (id != tasKDTO.Id)
            {
                return BadRequest("ID mismatch between URL and DTO");
            }
            var UpdateTask = _mapper.Map<TasK>(tasKDTO);
           var TaskService =   await _genericServices.PutAsync(id, UpdateTask);

            if (TaskService != null)
            {
                return NoContent(); 
            }
            else
            {
                return BadRequest("Task could not be updated.");
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult>  Remove(int id)
        {
            var success = await _genericServices.RemoveAsync(id);
            if (success)
            {
                return NoContent(); 
            }
            else
            {
                return BadRequest("Task could not be deleted.");
            }


        }
        
    
}



}
