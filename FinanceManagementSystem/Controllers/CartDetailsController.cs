using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceManagementSystem.Connection;
using CartApi.Models;
using Mysqlx.Crud;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly AppDbContext _cartdetails;
        private readonly IWebHostEnvironment _environment;

        private readonly IConfiguration  _configuration;


        public CartDetailsController(AppDbContext cartdetails, IWebHostEnvironment environment , IConfiguration configuration)
        {
            _cartdetails = cartdetails;
            _environment = environment;
            _configuration = configuration;
        }
        [HttpGet("{cartid}")]
        public async Task<CartDetails> GetById(int cartid)
        {
            return await _cartdetails.cartDetails.FindAsync(cartid);
        }
        [HttpGet("{id}/Image")]
        public IActionResult GetImage(int id)
        {
            var cart = _cartdetails.cartDetails.Find(id);
            if (cart == null)
            {
                return NotFound(); // User not found
            }

            // Construct the full path to the image file
            var imagePath = Path.Combine(_environment.WebRootPath, "images", cart.UniqueFileName);

            // Check if the image file exists
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Image file not found
            }

            // Serve the image file
            return PhysicalFile(imagePath, "image/jpeg");
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] CartDetails cart)
        {
            if (cart.ProfileImage != null && cart.ProfileImage.Length > 0)
            {
                // Generate a unique file name
                var uniqueFileName = $"{Guid.NewGuid()}_{cart.ProfileImage.FileName}";

                // Save the image to a designated folder (e.g., wwwroot/images)
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await cart.ProfileImage.CopyToAsync(stream);
                }

                // Store the file path in the database
                cart.UniqueFileName = uniqueFileName;
            }

            _cartdetails.cartDetails.Add(cart);
            await _cartdetails.SaveChangesAsync();

            return Ok();
        }



        [HttpGet]
        public IActionResult GetAllCart()
        {
            var carts = _cartdetails.cartDetails.ToList();

            var cartList = new List<object>();

            foreach (var cart in carts)
            {

                var cartData = new
                {
                    id = cart.id,
                    title = cart.title,
                    price = cart.price,
                    imageUrl = String.Format("{0}://{1}{2}/wwwroot/images/{3}", Request.Scheme, Request.Host, Request.PathBase, cart.UniqueFileName),
                    product_description= cart.product_description
                };

                cartList.Add(cartData);
            }

            return Ok(cartList);
        }


        [Route("api/Delete_product/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Deleteproduct(int id)
        {
            if (id < 1)
                return BadRequest();
            var deleteproduct = await _cartdetails.cartDetails.FindAsync(id);
            if (deleteproduct == null)
                return NotFound();
            _cartdetails.cartDetails.Remove(deleteproduct);
            await _cartdetails.SaveChangesAsync();
            return Ok();
        }



    }
}
