namespace Core.Entities
{
    public class Job
    {
        public long id { get; set; }
        public string? jobid { get; set; }
        public string? publishedAt { get; set; }
        public string? salary { get; set; }
        public string? title { get; set; }
        public string? jobUrl { get; set; }
        public string? companyName { get; set; }
        public string? companyUrl { get; set; }
        public string? location { get; set; }
        public string? postedTime { get; set; }
        public string? applicationsCount { get; set; }
        public string? description { get; set; }
        public string? contractType { get; set; }
        public string? experienceLevel { get; set; }
        public string? workType { get; set; }
        public string? sector { get; set; }
        public string? companyId { get; set; }
        public string? posterProfileUrl { get; set; }
        public string? posterFullName { get; set; }
        public float? Lang { get; set; }
        public float? lat { get; set; }
    }
}
