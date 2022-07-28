using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Mumbaidabba.Models
{
    public class DabbaCategory
    {
        public int DabbaCategoryId { get; set; }
        public string DabbaCategoryName { get; set; }
        public string DabbaCategoryDesc { get; set; }

    }
    //public class Products
    //{
    //    public int ProductId { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public decimal Price { get; set; }
    //    public int Quantity { get; set; }
    //    public int CategoryId { get; set; }
    //    public bool IsActive { get; set; }
    //    public DateTime CreatedDate { get; set; }
       
    //    public int DbCtgId { get; set; }
    //}
    public class Carts
    {
        public int CartId { get; set; }
        [ForeignKey("dabbaCategory")]
        public int DbCtgId { get; set; }
        public DabbaCategory dabbaCategory { get; set; }

        public int Quantity { get; set; }
        [ForeignKey("user")]
        public int usrid { get; set; }
        public User user { get; set; }

        public float Price { get; set; }
        public DateTime timeStamp { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string Password { get; set; }
        public bool UserType { get; set; }
        [NotMapped]
        public IFormFile UserImage { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class Booking
    {
        public int BookingDetailsId { get; set; }
        public string BookingNo { get; set; }
        [ForeignKey("dabbaCategory")]
        public int DbCtgId { get; set; }
        public DabbaCategory dabbaCategory { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("user")]
        public int usrid { get; set; }
        //public DateTime plan { get; set; }   
        //public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
    }
    public class Contact
    {

        public string Name { get; set; }
        public string Email { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class Dabbawala
    {
        public int dabbawalaId { get; set; }
        public string IdProof { get; set; }
        public int IdNumber { get; set; }
        [NotMapped]
        public IFormFile IdImage { get; set; }
        public string ImageUrl { get; set; }
        public string dabbawalaName { get; set; }
        public string location { get; set; }
        public string dabbawalaDesc { get; set; }
    }

    public class DabbaContext : DbContext
    {
        public DabbaContext(DbContextOptions<DabbaContext> options) : base(options) { }
        public DbSet<DabbaCategory> dabbaCategory { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<Carts> carts { get; set; }
        public DbSet<Contact> contact { get; set; }
        public DbSet<Dabbawala> dabbawala { get; set; }
        
    }
}
 
