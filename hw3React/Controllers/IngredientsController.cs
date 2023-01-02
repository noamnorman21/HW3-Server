using hw3React.DTO;
using hw3React.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hw3React.Controllers
{
    public class IngredientsController : ApiController
    {
        NoamEntities db = new NoamEntities();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<Ingredients> ingredients = db.Ingredients.ToList();
            List<IngredientsDto> ingredientsDto = new List<IngredientsDto>();
            try
            {
                foreach (Ingredients i in ingredients)
                {
                    IngredientsDto iDto = new IngredientsDto();
                    iDto.ingredientId = Convert.ToInt32(i.ingredientId);
                    iDto.ingredientName = i.ingredientsName;
                    iDto.calories = Convert.ToInt32(i.calories);
                    iDto.imgUrl = i.imgUrl;
                    ingredientsDto.Add(iDto);
                }
                return Ok(ingredientsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Ingredients value)
        {
            try
            {
                Ingredients i = value;
                db.Ingredients.Add(i);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}