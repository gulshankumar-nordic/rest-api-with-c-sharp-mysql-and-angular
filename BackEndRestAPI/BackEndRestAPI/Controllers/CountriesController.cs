using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly DbApplicationContext appContext;
        public CountriesController(DbApplicationContext context)
        {
            appContext = context;
        }
        // GET: api/<CountriesController>
        [HttpGet]
        public ActionResult<List<Countries>> Get()
        {
            try
            {
                var listCountries = appContext.Countries.ToList();
                return Ok(listCountries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public ActionResult<Countries> Get(int id)
        {
            try
            {
                var country = appContext.Countries.Find(id);
                if(country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // POST api/<CountriesController>
        [HttpPost]
        public ActionResult Post([FromBody] Countries country)
        {
            try
            {
                appContext.Add(country);
                appContext.SaveChanges();
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Countries country)
        {
            try
            {
                if(id != country.Id )
                {
                    return BadRequest();
                }
                appContext.Entry(country).State = EntityState.Modified;
                appContext.Update(country);
                appContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var country = appContext.Countries.Find(id);
                if(country == null)
                {
                    return NotFound();
                }
                appContext.Remove(country);
                appContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
