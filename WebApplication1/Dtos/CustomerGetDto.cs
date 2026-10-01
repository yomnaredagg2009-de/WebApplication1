namespace WebApplication1.Dtos
{
    public class CustomerGetDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public CustomerProfileDto Profile { get; set; }
        public int TotalVehiclesPurchased { get; set; }
        public decimal TotalMoneySpent { get; set; }
    }
}
