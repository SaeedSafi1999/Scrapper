using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Infrestructure.DataContext;
using Newtonsoft.Json;
using RestSharp;

namespace Services.ApplicationServices;

public class LinkedInScrapper : ILinkedInScrapper
{
    private readonly AppDataContext _db;

    public LinkedInScrapper(AppDataContext db)
    {
        _db = db;
    }

    public async Task<bool> Scrap(LinkedInScrapperDTO Request)
    {
        double[] coordinates = new double[2];


        var impoerRequest = JsonConvert.SerializeObject(Request);
        var client = new RestClient();
        var request = new RestRequest("https://linkedin-jobs-scraper-api.p.rapidapi.com/jobs", Method.Post);
        request.AddHeader("content-type", "application/json");
        request.AddHeader("X-RapidAPI-Key", "31e3dcd40bmshd6612a030d111dbp1d3348jsn10a4793c4c27");
        request.AddHeader("X-RapidAPI-Host", "linkedin-jobs-scraper-api.p.rapidapi.com");
        request.AddParameter("application/json", impoerRequest, ParameterType.RequestBody);
        var response = client.Execute(request);
        var result = JsonConvert.DeserializeObject<List<JobDTO>>(response.Content);

        foreach (var item in result)
        {
            if (!String.IsNullOrEmpty(item.location))
            {
                var clientcity = new RestClient();
                var requestcity = new RestRequest("https://nominatim.openstreetmap.org/search", Method.Get);
                requestcity.AddParameter("format", "json");
                requestcity.AddParameter("q", item.location);
                requestcity.AddParameter("limit", "1");
                var responsecity = clientcity.Execute(requestcity);
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(responsecity.Content);


                coordinates[0] = (double)data[0].lat;
                coordinates[1] = (double)data[0].lon;
            }

            await _db.Jobs.AddAsync(new Job
            {
                applicationsCount = item.applicationsCount,
                companyId = item.companyId,
                companyName = item.companyName,
                companyUrl = item.companyUrl,
                contractType = item.contractType,
                description = item.description,
                experienceLevel = item.experienceLevel,
                jobid = item.id.ToString(),
                jobUrl = item.jobUrl,
                Lang = (float?)coordinates[1],
                lat = (float?)coordinates[0],
                location = item.location,
                postedTime = item.postedTime,
                posterFullName = item.posterFullName,
                posterProfileUrl = item.posterProfileUrl,
                publishedAt = item.publishedAt,
                salary = item.salary,
                sector = item.sector,
                title = item.title,
                workType = item.workType,
            });
        }
        await _db.SaveChangesAsync();
        return true;

    }
}

public class JobDTO
{
    public long id { get; set; }
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

