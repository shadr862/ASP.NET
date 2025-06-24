namespace QuestuonAndAnswer.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

}
