
using API.Models;
using CartApi.Models;
using EMI_cards_2.Models;
using Form3final.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementSystem.Connection
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Signup> Signup { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<FormModel> Formdetails { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<EMIcardModels> Emi_cards_table { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<CartDetails> cartDetails { get; set; }

        //public Microsoft.EntityFrameworkCore.DbSet<Adminsignup> AdminSignup {  get; set; }


    }
}
