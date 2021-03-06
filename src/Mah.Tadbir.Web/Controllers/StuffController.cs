using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mah.Tadbir.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StuffController : ControllerBase
    {
        private readonly IStuffService _StuffService;

        public StuffController(IStuffService stuffService)
        {
            _StuffService = stuffService;
        }

        [HttpGet]
        public Task<IEnumerable<Stuff>> Get()
        {
            return _StuffService.GetAllStuff();
        }

        [HttpGet("{id:int}")]
        public Task<Stuff> Get(int id)
        {
            return _StuffService.GetStuffById(id);
        }

        [HttpDelete("{id:int}")]
        public Task Delete(int id)
        {
             return _StuffService.Delete(new Stuff() { Id = id });
        }

        [HttpPut]
        public Task Put(Stuff stuff)
        {
            return _StuffService.Update(stuff);
        }

        [HttpPost]
        public Task Post(Stuff stuff)
        {
            return _StuffService.Add(stuff);
        }
    }
}
