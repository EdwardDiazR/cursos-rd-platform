namespace CursosRDApi.Models.DTO.CourseDTOs
{
    public record CreateCourseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Language { get; set; }
        public int TeacherId { get; set; }
        public List<string> TitleKeywords { get; set; }
    }
}
