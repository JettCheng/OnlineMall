namespace Core.Dtos
{
    public class ProductTypeDto
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public int Level { get; set; }

        public string ParentId { get; set; }
    }
}