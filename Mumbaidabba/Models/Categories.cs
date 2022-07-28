namespace Mumbaidabba.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
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
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }

    }
    public class Orders
    {
        public int OrderDetailsId { get; set; }
        public string OrderNo { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
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

}
 
