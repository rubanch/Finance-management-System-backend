using FinanceManagementSystem.Connection;
using EMI_cards_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMI_cards_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext context;
        public ValuesController(AppDbContext context)
        {
            this.context = context;
        }

        [Route("api/Add_Emi_card")]
        [HttpPost]
        public async Task<IActionResult> Post(EMIcardModels emi_cardmodel)
        {
            try
            {
                context.Add(emi_cardmodel);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Get_EMI_Card")]
        [HttpGet]
        public async Task<IEnumerable<EMIcardModels>> Get()
        {
            return await context.Emi_cards_table.ToListAsync();
        }



        //[Route("api/Get_Product_throughID/{id}")]
        //[HttpGet]
        //public ActionResult<EMIcardModels> GetIndividual(int id)
        //{
        //    var movie = context.Emi_cards_table.Find(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(movie);
        //}




        [Route("api/Delete_EMI_card/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var Details = await context.Emi_cards_table.FindAsync(id);
            if (Details == null)
                return NotFound();
            context.Emi_cards_table.Remove(Details);
            await context.SaveChangesAsync();
            return Ok();
        }

        [Route("api/feth_through/{id}")]
        [HttpGet]
        public ActionResult<EMIcardModels> GetIndividual(int id)
        {
            var cardinfo = context.Emi_cards_table.Find(id);
            if (cardinfo == null)
            {
                return NotFound();
            }
            return Ok(cardinfo);
        }
    }
}
