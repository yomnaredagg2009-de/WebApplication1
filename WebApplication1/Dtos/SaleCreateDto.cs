namespace WebApplication1.Dtos
{
    public class SaleCreateDto
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
        public decimal SalePrice { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
    }
}
