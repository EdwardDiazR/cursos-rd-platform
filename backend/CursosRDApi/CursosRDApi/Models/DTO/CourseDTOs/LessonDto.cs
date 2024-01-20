namespace CursosRDApi.Models.DTO.CourseDTOs
{
    public record LessonDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }

        public int CourseId { get; set; }
        public bool IsVisible { get; set; }
        public int SectionId { get; set; }

    }
}
