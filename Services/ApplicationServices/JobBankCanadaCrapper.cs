using Core.Entities;
using Core.Interfaces;
using Infrestructure.DataContext;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Services.ApplicationServices
{
    public class JobBankCanadaCrapper : IJobBankCanadaCrapper
    {
        private readonly AppDataContext _db;

        public JobBankCanadaCrapper(AppDataContext db)
        {
            _db = db;
        }

        public async Task<bool> ScrapJobBankSite()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AcceptInsecureCertificates = true;
            //firefoxOptions.BrowserExecutableLocation = Path.Combine(Directory.GetCurrentDirectory(), "Firefox.exe");
            WebDriver drive = new FirefoxDriver(firefoxOptions);
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
                    await _db.Jobs.AddAsync(new Job
                    {
                        City = City,
                        JobTitel = JobTitel,
                        Salary = Salary,
                        Time = Time,
                        WorkHour = WorkHour,
                        Lang = 121221,
                        lat = 1313123
                    });
                }


                //close the second page(job detail)
                drive.SwitchTo().Window(drive.WindowHandles.Last()).Close();
                //swipe back to first page
                drive.SwitchTo().Window(drive.WindowHandles.First());

            }
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
