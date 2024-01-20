namespace CursosRDApi.Models.DTO.UserDTOs
{
    public record LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
