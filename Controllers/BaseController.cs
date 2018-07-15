using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using blog_api_dotnet_core2.Models;
using blog_api_dotnet_core2.Interfaces;

namespace blog_api_dotnet_core2.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity> : Controller where TEntity : BaseModel
    {
        public abstract String ApiUrl { get; }
        
        private readonly IRepository<TEntity> _repository;

        public BaseController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        // GET api/api-url
        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return _repository.FindAll();
        }

        // GET api/api-url/5
        [HttpGet("{id}")]
        public TEntity Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/api-url
        [HttpPost]
        public ObjectResult Post([FromBody] TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest("You must send a valid object in json format!");
            }
            
            var id = _repository.Add(entity).ToString();

            return Created(new Uri($"/{this.ApiUrl}/{id}", UriKind.Relative), new { Id = id });
        }

        // PUT api/api-url/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(Guid id, [FromBody] TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            entity.Id = id;
            _repository.Update(entity);

            return Ok();
        }

        // DELETE api/api-url/5
        [HttpDelete("{id}")]
        public NoContentResult Delete(Guid id)
        {
            _repository.Delete(id);

            return NoContent();
        }
    }
}
