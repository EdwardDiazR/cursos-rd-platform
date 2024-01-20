namespace CursosRDApi.Models.DTO.CourseDTOs
{
    public class UpdateCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Language { get; set; }
        public string? ThumbnailImageUrl { get; set; }
    }
}
