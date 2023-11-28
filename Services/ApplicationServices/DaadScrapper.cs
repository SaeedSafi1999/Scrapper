using Core.Interfaces;
using Infrestructure.DataContext;
using RestSharp;

namespace Services.ApplicationServices
{
    public class DaadScrapper : IDaadScrapper
    {
        private readonly AppDataContext _db;

        public DaadScrapper(AppDataContext db)
        {
            _db = db;
        }

        Root GetDataFromDaadWebSite()
        {
            var restClient = new RestClient("https://www2.daad.de/deutschland/studienangebote/international-programmes/api/solr/en/search.json?cert=&admReq=&langExamPC=&scholarshipLC=&langExamLC=&scholarshipSC=&langExamSC=&degree%5B%5D=1&degree%5B%5D=2&degree%5B%5D=3&degree%5B%5D=7&degree%5B%5D=5&degree%5B%5D=6&fos=&langDeAvailable=&langEnAvailable=&lang%5B%5D=1&lang%5B%5D=2&lang%5B%5D=4&lang%5B%5D=3&fee=&sort=4&dur=&q=&limit=1000&offset=1000&display=list&isElearning=&isSep=");
            var request = new RestRequest("https://www2.daad.de/deutschland/studienangebote/international-programmes/api/solr/en/search.json?cert=&admReq=&langExamPC=&scholarshipLC=&langExamLC=&scholarshipSC=&langExamSC=&degree%5B%5D=1&degree%5B%5D=2&degree%5B%5D=3&degree%5B%5D=7&degree%5B%5D=5&degree%5B%5D=6&fos=&langDeAvailable=&langEnAvailable=&lang%5B%5D=1&lang%5B%5D=2&lang%5B%5D=4&lang%5B%5D=3&fee=&sort=4&dur=&q=&limit=1000&offset=1000&display=list&isElearning=&isSep="
                , Method.Get);

            var response = restClient.Execute<Root>(request);

            return response.Data;
        }

        public async Task<bool> ScrapDaad()
        {
            try
            {
                var res = GetDataFromDaadWebSite();
                List<Course> Datas = new List<Course>();
                Datas.AddRange(res.courses);
                foreach (var item in Datas)
                {
                    double[] coordinates = new double[2];
                    if (!String.IsNullOrEmpty(item.city))
                    {
                        var client = new RestClient();
                        var request = new RestRequest("https://nominatim.openstreetmap.org/search", Method.Get);
                        request.AddParameter("format", "json");
                        request.AddParameter("q", item.city);
                        request.AddParameter("limit", "1");
                        var response = client.Execute(request);
                        dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);


                        coordinates[0] = (double)data[0].lat;
                        coordinates[1] = (double)data[0].lon;
                    }


                    await _db.Ejucations.AddAsync(new Core.Entities.Ejucation
                    {
                        Academy = item.academy,
                        badgeLabel = !String.IsNullOrEmpty(item.badgeLabel) ? "Nodata" : item.badgeLabel,
                        Beginning = item.beginning,
                        City = item.city,
                        CourseName = item.courseName,
                        CourseShortName = item.courseNameShort,
                        idSite = item.id,
                        Image = !String.IsNullOrEmpty(item.image) ? "Nodata" : item.image,
                        isCompleteOnlinePossible = item.isCompleteOnlinePossible,
                        isElearning = item.isElearning,
                        lang = (float?)coordinates[0] == null ? 0 : (float?)coordinates[0],
                        lat = (float?)coordinates[1] == null ? 0 : (float?)coordinates[1],
                        link = item.link,
                        ProgrammeDuration = item.programmeDuration,
                        requestLanguage = item.requestLanguage,
                        structuredResearch = !item.structuredResearch.HasValue ? false : (bool)item.structuredResearch,
                        subject = item.subject,
                        typeCourseDate = !String.IsNullOrEmpty(item.typeCourseDate) ? "Nodata" : item.typeCourseDate,
                    });
                }
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }


        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Bgn
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Cit
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Course
        {
            public int id { get; set; }
            public string image { get; set; }
            public string courseName { get; set; }
            public string courseNameShort { get; set; }
            public string academy { get; set; }
            public string city { get; set; }
            public List<string> languages { get; set; }
            public List<string> languageLevelGerman { get; set; }
            public List<string> languageLevelEnglish { get; set; }
            public string beginning { get; set; }
            public string programmeDuration { get; set; }
            public List<Date> date { get; set; }
            public string typeCourseDate { get; set; }
            public string costString { get; set; }
            public string tuitionFees { get; set; }
            public int courseType { get; set; }
            public bool isElearning { get; set; }
            public List<string> preparationForDegree { get; set; }
            public List<string> preparationForSubjectGroups { get; set; }
            public string applicationDeadline { get; set; }
            public bool isCompleteOnlinePossible { get; set; }
            public string badgeLabel { get; set; }
            public object financialSupport { get; set; }
            public bool? structuredResearch { get; set; }
            public List<string> supportInternationalStudents { get; set; }
            public string subject { get; set; }
            public List<string> typeOfElearning { get; set; }
            public string link { get; set; }
            public string requestLanguage { get; set; }
        }

        public class Dat
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Date
        {
            public string start { get; set; }
            public string end { get; set; }
            public int costs { get; set; }
            public string registrationDeadline { get; set; }
            public string selectHskHwk { get; set; }
        }

        public class Degree
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Dur
        {
            public string label_after { get; set; }
            public string label_before { get; set; }
            public string value { get; set; }
            public int count { get; set; }
        }

        public class ElearningElement
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Fee
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Filter
        {
            public List<Degree> degree { get; set; }
            public List<Lang> lang { get; set; }
            public List<Fo> fos { get; set; }
            public List<Subject> subjects { get; set; }
            public List<Cit> cit { get; set; }
            public List<Tyi> tyi { get; set; }
            public List<In> ins { get; set; }
            public int cert { get; set; }
            public int admReq { get; set; }
            public int langExamPC { get; set; }
            public int langExamLC { get; set; }
            public int langExamSC { get; set; }
            public int scholarshipLC { get; set; }
            public int scholarshipSC { get; set; }
            public List<LvlDe> lvlDe { get; set; }
            public List<LvlEn> lvlEn { get; set; }
            public int langDeAvailable { get; set; }
            public int langEnAvailable { get; set; }
            public List<ModStd> modStd { get; set; }
            public List<Bgn> bgn { get; set; }
            public List<Dat> dat { get; set; }
            public List<Dur> dur { get; set; }
            public List<Fee> fee { get; set; }
            public List<PrepSubj> prep_subj { get; set; }
            public List<PrepDegree> prep_degree { get; set; }
            public List<ElearningElement> elearning_element { get; set; }
        }

        public class Fo
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class In
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Lang
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class LvlDe
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class LvlEn
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class ModStd
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class PrepDegree
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class PrepSubj
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Root
        {
            public List<Course> courses { get; set; }
            public int numResults { get; set; }
            public Filter filter { get; set; }
        }

        public class Subject
        {
            public string value { get; set; }
            public int count { get; set; }
        }

        public class Tyi
        {
            public string value { get; set; }
            public int count { get; set; }
        }


    }
}
