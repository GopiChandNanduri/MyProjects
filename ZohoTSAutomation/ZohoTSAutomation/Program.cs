// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Globalization;

Console.WriteLine("Hello, World!");


IWebDriver driver = new ChromeDriver();
// Navigate to the URL
driver.Navigate().GoToUrl("https://www.zoho.com/people/?zsrc=fromproduct#home/dashboard");
driver.Manage().Window.Maximize();

// Search the SignIn button
driver.FindElement(By.ClassName("zgh-login")).Click();

// enter email 
IWebElement loginBox = driver.FindElement(By.Name("LOGIN_ID"));
loginBox.SendKeys(""); // add email address

// Select Next button with span Next
driver.FindElement(By.Id("nextbtn")).Click();

// Enter Password 
IWebElement passwordBox = driver.FindElement(By.Name("PASSWORD"));
passwordBox.SendKeys(""); // add password

// Select SignIn button with span "Sign in"
driver.FindElement(By.Id("nextbtn")).Click();

// Goto TimeTracker tab zp_maintab_timetracker
driver.FindElement(By.Id("zp_maintab_timetracker")).Click();

// Goto List view tab zp_t_timetracker_timelogs_listview
driver.FindElement(By.Id("zp_t_timetracker_timelogs_listview")).Click();

// Goto List view tab addtimelogbutton
driver.FindElement(By.Id("addtimelogbutton")).Click();

// select client Internal iGD, ANZ
SelectElement dropDownClient = new SelectElement(driver.FindElement(By.Id("s2id_timelogClient")));
dropDownClient.SelectByValue("ANZ");

// select project iGD Internal, Payments, Business Lending
SelectElement dropDownProject = new SelectElement(driver.FindElement(By.Id("s2id_timelogProject")));
dropDownProject.SelectByValue("Payments");

// select project iGD Internal, Payments, Business Lending
SelectElement dropDownJob = new SelectElement(driver.FindElement(By.Id("s2id_timelogJob")));
dropDownJob.SelectByValue("Development");

// Select the week from configuration
DayOfWeek currentDay = DateTime.Now.DayOfWeek;
int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);

// If you want for multiple weeks add one more loop on existing loop
for (int i = 0; i < 4; i++)
{
    currentWeekStartDate = DateTime.Now.AddDays(i);
    string date = currentWeekStartDate.Date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
    driver.FindElement(By.Id("zp_field_46965000000064689")).SendKeys(date);
}

