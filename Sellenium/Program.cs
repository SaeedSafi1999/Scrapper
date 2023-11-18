using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Globalization;

IWebDriver drive = new FirefoxDriver();
List<JobDTO> jobs = new List<JobDTO>();
drive.Url = "https://www.jobbank.gc.ca/jobsearch";
Thread.Sleep(3000);
for (int i = 0; i < 5; i++)
{
    drive.FindElement(By.CssSelector("#morepage button")).Click();
    var hrefs = drive.FindElements(By.CssSelector(".resultJobItem")).Select(x => x.GetAttribute("href")).ToList();
    drive.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
    drive.SwitchTo().NewWindow(WindowType.Tab);
    drive.SwitchTo().Window(drive.WindowHandles.Last());
    int counter = 0;

    foreach (var item in hrefs)
    {
        counter++;
        if (counter == 1)
        {
            continue;
        }
        //navigate to second page(job detial)
        drive.Navigate().GoToUrl(item);

        //get values by css selector
        var JobTitel = drive.FindElement(By.CssSelector("#wb-cont")).Text;
        var City = drive.FindElement(By.CssSelector(".city")) != null ? drive.FindElement(By.CssSelector(".city span")).Text : null;
        var Salary = drive.FindElement(By.CssSelector(".attribute-value > span > span:nth-child(2)")).Text;
        var WorkHour = drive.FindElement(By.CssSelector(".attribute-value > span:nth-child(2)")).Text;
        var Time = drive.FindElement(By.CssSelector(".job-posting-brief > li:nth-child(3) > span:nth-child(3) > span ")).Text;

        //map to specefic class
        jobs.Add(new JobDTO
        {
            City = City,
            jobTitel = JobTitel,
            Salary = Salary,
            Time = Time,
            WorkHour = WorkHour,
        });
    }

    //close the second page(job detail)
    drive.SwitchTo().Window(drive.WindowHandles.Last()).Close();
    //swipe back to first page
    drive.SwitchTo().Window(drive.WindowHandles.First());
}

//write to csv
using (var writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "CanadaJobs.csv")))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csv.WriteRecords(jobs);
}

//print this if it has no error
Console.WriteLine("compeleted!");


// class that jobs mapped to
public class JobDTO
{
    public string jobTitel { get; set; }
    public string City { get; set; }
    public string Salary { get; set; }
    public string WorkHour { get; set; }
    public string Time { get; set; }
}