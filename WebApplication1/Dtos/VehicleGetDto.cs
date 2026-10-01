namespace WebApplication1.Dtos
{
    public class VehicleGetDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string CategoryName { get; set; }
    }
}
