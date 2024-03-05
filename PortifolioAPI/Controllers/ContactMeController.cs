using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortifolioAPI.Models;
using PortifolioAPI.Models.Dto;
using PortifolioAPI.Repository.IRepository;

namespace PortifolioAPI.Controllers
{
    [Route("api/PortifolioAPI")]
    [ApiController]
    public class ContactMeController : ControllerBase
    {
        private readonly IContactRepository _dbContactMe;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public ContactMeController(IContactRepository dbContactMe, IMapper mapper)
        {
            _dbContactMe = dbContactMe;
            _mapper = mapper;
            this._response = new();
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact([FromBody] ContactDto createDto) 
        {
            if (createDto == null || createDto.Id > 0)
            {
                return BadRequest();
            }
            if (await _dbContactMe.GetIdAsync(c => c.Email.ToLower() == createDto.Email.ToLower()) != null)
            {
                ModelState.AddModelError("CustomErro", "Email já existe");
                
                return BadRequest(ModelState);
            }

            Contact contact = _mapper.Map<Contact>(createDto);

            await _dbContactMe.CreateContactAsync(contact);
            await _dbContactMe.SaveAsync();

            _response.Result = _mapper.Map<Contact>(contact);
            _response.StatusCode = System.Net.HttpStatusCode.Created;
            _response.IsSuccess = true;

            return Created("Created success!", _response);
        }   
    }
}
