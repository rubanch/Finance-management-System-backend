using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using FinanceManagementSystem.Connection;
namespace API.Controllers; 



[ApiController]
[Route("api/[controller]")]

// [EnableCors(origins : "http://localhost:3001/sign-up", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]  
public class SignupController : ControllerBase
{
   private readonly AppDbContext _context;
   public SignupController(AppDbContext context)
   {
      _context = context;
   }


   [HttpPost]

   public async Task<ActionResult<Signup>> Create(Signup Signup)
   {
      _context.Add(Signup);

      await _context.SaveChangesAsync();
      return Ok(Signup);
   }

   [Route("api/Signin")]




   [HttpPost]

   public async Task<IActionResult> Signin(Signin user)
   {
      try
      {
         Signup olduser = _context.Signup.Where(user1 => user1.Email == user.Email).FirstOrDefault()!;

         if (olduser.Email == user.Email && olduser != null)
         {
            if (olduser.Password == user.Password)
            {
               return Ok("{\"emailstatus\":true,\"passwordstatus\":true}");
            }
            else
            {
               return Ok("{\"emailstatus\":true,\"passwordstatus\":false}");
            }
         }
      }
      catch (Exception ex)
      {
         return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");

      }
      return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");


   }
}

