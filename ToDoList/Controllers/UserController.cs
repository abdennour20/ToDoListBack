using Application.DTOs;
using Application.Intrfraces;
using AutoMapper;
using Domain.Entites;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericServices<User> _genericServices;
        private readonly IMapper _mapper;
        public UserController(IGenericServices<User> genericServices , IMapper mapper) {

            _genericServices = genericServices;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> Get(int id  )
              {
            var user = await _genericServices.GetAsync(id , u=>u.AssignedTasks);
            if (user == null )
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var Tasks = await _genericServices.GetAllAsync(t => t.AssignedTasks);
            if (Tasks == null)
            {
                return NotFound();
            }
            return Ok(Tasks);
        }
        [HttpPost]
        public async Task<IActionResult>  Post(UserDTO userDTO)
        {

            var user = _mapper.Map<User>(userDTO);
            var success = await _genericServices.PostAsync(user);

            if (success)
            {
                return CreatedAtAction(nameof(Get), new { id = user.Id }, userDTO);
            }
            else
            {
                return BadRequest("User could not be added.");
            }
        }


    }

    }

         
    

