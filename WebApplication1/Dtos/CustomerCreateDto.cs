namespace WebApplication1.Dtos
{
    public class CustomerCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DriverLicenseNumber { get; set; }
        public CustomerProfileDto Profile { get; set; }
    }
}
