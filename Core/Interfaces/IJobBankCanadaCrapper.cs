namespace Core.Interfaces
{
    public interface IJobBankCanadaCrapper
    {
        Task<bool> ScrapJobBankSite();
    }
}
