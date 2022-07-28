using System.ComponentModel.DataAnnotations.Schema;

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
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
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
        [ForeignKey("DabbaCategory")]
        public int DbCtgId { get; set; }
        public string DabbaCategoryName { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int PaymentId { get; set; }
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

    public class dabbawala
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

    public class sam
    {
        public int samId { get; set; }
    }

}
 
