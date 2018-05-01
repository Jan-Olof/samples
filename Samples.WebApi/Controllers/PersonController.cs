using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Samples.ApplicationLayer;
using Samples.ApplicationLayer.Persons;
using Samples.DomainLayer.Persons;
using Samples.InfrastructureLayer.Persons;
using Samples.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Samples.WebApi.Controllers
{
    /// <summary>
    /// The person controller handles all persons.
    /// </summary>
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPersonInteractor _personInteractor;
        private readonly IQueries<IPersonDto> _personQueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController" /> class.
        /// </summary>
        public PersonController(IMapper mapper, IPersonInteractor personInteractor, IQueries<IPersonDto> personQueries)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _personInteractor = personInteractor ?? throw new ArgumentNullException(nameof(personInteractor));
            _personQueries = personQueries ?? throw new ArgumentNullException(nameof(personQueries));
        }

        /// <summary>
        /// Delete an existing person
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(HttpError), (int)HttpStatusCode.InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(string id)
        {
            var guid = new Guid(id);

            _personInteractor.RemovePerson(guid);

            return new NoContentResult();
        }

        /// <summary>
        /// Get all persons.
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<IPersonDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(HttpError), (int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var persons = _personQueries.GetAll();

            if (persons == null || !persons.Any())
            {
                return NotFound("No persons found.");
            }

            return Ok(persons);
        }

        /// <summary>
        /// Get a person from id.
        /// </summary>
        [ProducesResponseType(typeof(IPersonDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(HttpError), (int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetPerson(string id)
        {
            var guid = new Guid(id);

            var person = _personQueries.Get(guid);

            if (person == null)
            {
                return NotFound($"No person found with id {id}.");
            }

            return Ok(person);
        }

        /// <summary>
        /// Create a new person.
        /// </summary>
        [ProducesResponseType(typeof(PersonDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(HttpError), (int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public IActionResult PostPerson([FromBody]CreatePersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);

            var createdPerson = _personInteractor.CreatePerson(person);

            var createdPersonDto = _mapper.Map<PersonDto>(createdPerson);

            return CreatedAtRoute("GetPerson", new { id = createdPersonDto.Id }, createdPersonDto);
        }

        /// <summary>
        /// Edit an existing person
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(HttpError), (int)HttpStatusCode.InternalServerError)]
        [HttpPut]
        public IActionResult PutPerson([FromBody]PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);

            _personInteractor.EditPerson(person);

            return new NoContentResult();
        }
    }
}