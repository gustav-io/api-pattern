using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisualSoftware.Application.DTO.DTO;
using VisualSoftware.Application.Interfaces;
using VisualSoftware.Application.Responses;
using VisualSoftware.Domain.Core.Queries;

namespace VisualSoftware.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IApplicationServicePerson _applicationServicePerson;


        public PersonController(IApplicationServicePerson ApplicationServicePerson)
        {
            _applicationServicePerson = ApplicationServicePerson;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll([FromQuery]PaginationQuery paginationQuery)
        {
            return Ok(_applicationServicePerson.GetAll(paginationQuery));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServicePerson.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] PersonDTO PersonDTO)
        {
            try
            {
                if (PersonDTO == null)
                    return NotFound();

                _applicationServicePerson.Add(PersonDTO);
                return Ok(new Response<string>("Pessoa cadastrada com sucesso!"));
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] PersonDTO PersonDTO)
        {
            try
            {
                if (PersonDTO == null)
                    return NotFound();

                _applicationServicePerson.Update(PersonDTO);
                return Ok(new Response<string>("Pessoa atualizada com sucesso!"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] PersonDTO PersonDTO)
        {
            try
            {
                if (PersonDTO == null)
                    return NotFound();

                _applicationServicePerson.Remove(PersonDTO);
                return Ok(new Response<string>("Pessoa removida com sucesso!"));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}