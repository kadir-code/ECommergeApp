namespace EAPP.API.Models.DTOs
{
    public class CheckUserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }

    }
}
