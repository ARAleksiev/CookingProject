namespace Cooking.Models.EntityModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measure { get; set; }
        public double Quantity { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}