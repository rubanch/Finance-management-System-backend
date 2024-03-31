using FinanceManagementSystem.Connection;
using Form3final.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Form3final.Controllers
{
    [ApiController]
    public class FormController : Controller
    {
        private readonly AppDbContext context;
        public FormController(AppDbContext context){
            this.context=context; 
        }

        [Route("api/AddCardForm")]
        [HttpPost]
        public async Task<IActionResult> Post(FormModel formmodel)
        {
            try
            {
                context.Add(formmodel);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //get
        [Route("api/Get_Card_Info")]
        [HttpGet]
        public async Task<IEnumerable<FormModel>> Get()
        {
            return await context.Formdetails.ToListAsync();
        }


        [Route("api/Get_Card_Info_throughID/{id}")]
        [HttpGet]
        public ActionResult<FormModel> GetIndividual(int id)
        {
            var movie = context.Formdetails.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [Route("api/Delete_Card_form/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var Details = await context.Formdetails.FindAsync(id);
            if (Details == null)
                return NotFound();
            context.Formdetails.Remove(Details);
            await context.SaveChangesAsync();
            return Ok();
        }



    }
}
