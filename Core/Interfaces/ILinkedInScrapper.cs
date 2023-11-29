using Core.DTOs;

namespace Core.Interfaces
{
    public interface ILinkedInScrapper
    {
        Task<bool> Scrap(LinkedInScrapperDTO Request);
    }
}
