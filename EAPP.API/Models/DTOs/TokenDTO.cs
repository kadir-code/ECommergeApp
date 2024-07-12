namespace EAPP.API.Models.DTOs
{
    public class TokenDTO
    {
        public TokenDTO(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
