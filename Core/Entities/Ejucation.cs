namespace Core.Entities
{

    public class Ejucation
    {
        public int Id { get; set; }
        public int? idSite { get; set; }
        public string? Image { get; set; }
        public string? CourseName { get; set; }
        public string? CourseShortName { get; set; }
        public string? Academy { get; set; }
        public string? City { get; set; }
        public string? Beginning { get; set; }
        public string? ProgrammeDuration { get; set; }
        public string? typeCourseDate { get; set; }
        public bool? isElearning { get; set; }
        public bool? isCompleteOnlinePossible { get; set; }
        public string? badgeLabel { get; set; }
        public bool? structuredResearch { get; set; }
        public string? subject { get; set; }
        public string? link { get; set; }
        public string? requestLanguage { get; set; }
        public float? lat { get; set; }
        public float? lang { get; set; }

    }
}
