namespace WebApplication1.Dtos
{
    public class SaleReadDto
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public string PaymentMethod { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string VehicleModel { get; set; }
    }
}
