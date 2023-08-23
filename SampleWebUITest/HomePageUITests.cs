using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SampleWebUITest
{
    [TestClass]
    public class HomePageUITests
    {
        IWebDriver driver;

        static TestContext testContext;

        static string browser;
        static string appUrl;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            testContext = context;

            browser = testContext.Properties["browser"].ToString();
            appUrl = testContext.Properties["appUrl"].ToString();
        }

        [TestInitialize]
        public void Init()
        {
            driver = browser switch
            {
                "chrome" => new ChromeDriver(),
                "edge" => new EdgeDriver(),
                _ => new ChromeDriver()
            };
        }


        [TestMethod]
        public void Test_Home_Menu_Option()
        {
            driver.Navigate().GoToUrl(appUrl);
            Assert.IsTrue(driver.Title.StartsWith("Home"));
        }

        [TestMethod]
        public void Test_Privacy_Menu_Option()
        {
            driver.Navigate().GoToUrl(appUrl);
            driver.FindElement(By.LinkText("Privacy")).Click();
            Assert.IsTrue(driver.Title.StartsWith("Privacy"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
