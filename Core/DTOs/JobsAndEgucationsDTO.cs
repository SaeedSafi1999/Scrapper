using Core.Entities;

namespace Core.DTOs
{
    public class JobsAndEgucationsDTO
    {
        public IReadOnlyList<Job> Jobs { get; set; }
        public IReadOnlyList<Ejucation> Ejucations { get; set; }
    }
}
