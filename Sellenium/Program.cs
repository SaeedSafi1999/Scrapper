//using Newtonsoft.Json.Linq;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using System.Net;

//IWebDriver drive = new FirefoxDriver();
//List<JobDTO> jobs = new List<JobDTO>();
//drive.Url = "https://www.jobbank.gc.ca/jobsearch";
//Thread.Sleep(3000);
//for (int i = 0; i < 5; i++)
//{
//    drive.FindElement(By.CssSelector("#morepage button")).Click();
//    var hrefs = drive.FindElements(By.CssSelector(".resultJobItem")).Select(x => x.GetAttribute("href")).ToList();
//    drive.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
//    drive.SwitchTo().NewWindow(WindowType.Tab);
//    drive.SwitchTo().Window(drive.WindowHandles.Last());
//    int counter = 0;

//    foreach (var item in hrefs)
//    {
//        try
//        {
//            counter++;
//            if (counter == 1)
//            {
//                continue;
//            }

//            //navigate to second page(job detial)
//            drive.Navigate().GoToUrl(item);

//            //get values by css selector
//            var JobTitel = drive.FindElement(By.CssSelector("#wb-cont")).Text;
//            var City = drive.FindElement(By.CssSelector(".city")) != null ? drive.FindElement(By.CssSelector(".city span")).Text : null;
//            var Salary = drive.FindElement(By.CssSelector(".attribute-value > span > span:nth-child(2)")).Text;
//            var WorkHour = drive.FindElement(By.CssSelector(".attribute-value > span:nth-child(2)")).Text;
//            var Time = drive.FindElement(By.CssSelector(".job-posting-brief > li:nth-child(3) > span:nth-child(3) > span ")).Text;

//            //map to specefic class
//            jobs.Add(new JobDTO
//            {
//                City = City,
//                jobTitel = JobTitel,
//                Salary = Salary,
//                Time = Time,
//                WorkHour = WorkHour,
//            });
//        }
//        catch (Exception ex)
//        {

//        }

//    }

//    //close the second page(job detail)
//    drive.SwitchTo().Window(drive.WindowHandles.Last()).Close();
//    //swipe back to first page
//    drive.SwitchTo().Window(drive.WindowHandles.First());
//}

////write to csv
//using (var writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "CanadaJobs.csv")))
//using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
//{
//    csv.WriteRecords(jobs);
//}

////print this if it has no error
//Console.WriteLine("compeleted!");


//var options = new ChromeOptions();
//options.AddArguments(@"user-data-dir=C:\Users\Caro-2\AppData\Local\Google\Chrome\User Data\");
//options.AddArguments(@"profile-direction=C:\Users\Caro-2\AppData\Local\Google\Chrome\User Data\Profile 1");
//options.AddArguments("start-maximized"); // open Browser in maximized mode
//options.AddArguments("disable-infobars"); // disabling infobars
//options.AddArguments("--disable-extensions"); // disabling extensions
//options.AddArguments("--disable-gpu"); // applicable to windows os only
//options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
//options.AddArguments("--no-sandbox"); // Bypass OS security model
//options.PageLoadStrategy = PageLoadStrategy.Normal;

//IWebDriver drive = new FirefoxDriver();
////go to job url
//drive.Url = "https://www.flexjobs.com/search?search=it";
//var jobdivs = drive.FindElements(By.CssSelector("#joblist li"));
//var hrefs = jobdivs.Select(x => x.FindElement(By.CssSelector("div> div > div > div h5 a")).GetAttribute("href")).ToList();
//drive.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
//drive.SwitchTo().NewWindow(WindowType.Tab);
//drive.SwitchTo().Window(drive.WindowHandles.Last());
//int counter = 0;
//foreach (var job in hrefs)
//{
//    drive.Navigate().GoToUrl(job);
//    Thread.Sleep(2000);
//    var title = drive.FindElement(By.CssSelector("#content-main h1")).Text;
//    var description = drive.FindElement(By.CssSelector("#public-job-tab-content .job-description")).Text;
//    var location = drive.FindElement(By.CssSelector(".job-details >tbody tr:nth-child(3) td")).Text;
//}
//drive.SwitchTo().Window(drive.WindowHandles.Last()).Close();
////swipe back to first page
//drive.SwitchTo().Window(drive.WindowHandles.First());

////var JobDivs = drive.FindElements(By.CssSelector(".res-vurnku .res-j5y1mq"));
//var JobDivs = drive.FindElements(By.CssSelector(".res-vurnku article")).Where(x => x.GetAttribute("data-genesis-element") == "CARD");
//foreach (var item in JobDivs)
//{
//    try
//    {
//        item.Click();
//        Thread.Sleep(2000);

//    }
//    catch (Exception ex)
//    {
//        drive.SwitchTo().Window(drive.WindowHandles.First());
//        drive.FindElement(By.CssSelector("#job-agent-modal-dialog .job-agent-frontend-apps-16wuz8p .job-agent-frontend-apps-c454la button")).Click();
//    }

//    //drive.SwitchTo().Window(drive.WindowHandles.First());
//    //drive.Close();
//}

//var searchbox = drive.FindElement(By.CssSelector(".jobs-search-box__text-input"));
//var searchbox1 = drive.FindElement(By.CssSelector("#jobs-search-box-location-id-ember31"));
//searchbox.Clear();
//searchbox1.Clear();
//searchbox.SendKeys("Canada");
//searchbox1.SendKeys("Canada");
//drive.FindElement(By.CssSelector(".jobs-search-box__submit-button")).Click();




//IWebDriver drive = new ChromeDriver(options);
////go to job url
//drive.Url = "https://www.careerjet.de/suchen/stellenangebote?s=softwareentwickler&l=";
//Thread.Sleep(4000);



////select search textbox
//var SearchBox = drive.FindElement(By.CssSelector("#horizontal-input-one-undefined"));

////clear and set value to input
//SearchBox.Clear();
//SearchBox.SendKeys("IT");

////click on search btn
//drive.FindElement(By.CssSelector(".sc-jdUcAg")).Click();
//Thread.Sleep(2000);

//Thread.Sleep(5000);
////find li in jobs div
//int succes = 0;
//for (int i = 0; i < 3; i++)
//{
//    var JobDiv = drive.FindElements(By.CssSelector(".sc-harTkY li")).Skip(succes);
//    //click on job dive in 1000 millisecond
//    foreach (var item in JobDiv)
//    {
//        try
//        {
//            Thread.Sleep(5000);
//            var Div = item.FindElement(By.CssSelector(".job-search-resultsstyle__JobCardWrap-sc-1wpt60k-4"));

//            Div.Click();
//            Thread.Sleep(4000);
//            var jobTitle = drive.FindElement(By.CssSelector("body .JobViewTitle")).Text;
//            var City = drive.FindElement(By.CssSelector("body .JobViewTitle")).Text;
//            var detailsTBL = drive.FindElements(By.CssSelector("body #details-table"));
//            List<string> output = detailsTBL.Select(x => x.GetAttribute("innerHTML")).ToList();
//            succes++;
//        }
//        catch (Exception ex)
//        {
//            //throw;
//        }
//    }

//}


//var db = new AppDataContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDataContext>());
//var Data = new LinkedInScrapper(db);
//var data = await Data.Scrap(new Core.DTOs.LinkedInScrapperDTO
//{

//});

List<string> Countries = new List<string>() { "canada", "new york", "sweden", "berlin", "netherlands" };
var RandomNum = new Random();
var CountryName = Countries[RandomNum.Next(1, 5)];
Console.Write(CountryName);









public class JobDTO
{
    public string jobTitel { get; set; }
    public string City { get; set; }
    public string Salary { get; set; }
    public string WorkHour { get; set; }
    public string Time { get; set; }
}