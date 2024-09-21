namespace WebApplication1.Models
{
    public class ProductBL
    {
        List<Product> products;
        public ProductBL()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1 , Name = "InclineBenchPress" , ImageUrl = "1.jpg"});
            products.Add(new Product() { Id = 2 , Name = "BarbellRows" , ImageUrl = "2.jpeg"});
            products.Add(new Product() { Id = 3 , Name = "Squat" , ImageUrl = "3.jpg"});
        }
        public List<Product> GetAll()
        {
            return products;
        }
        public Product GetById(int id) 
        {
            return products.FirstOrDefault(p => p.Id == id);    
        }
    }
}
