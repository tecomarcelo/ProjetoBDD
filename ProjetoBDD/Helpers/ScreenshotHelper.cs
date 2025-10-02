using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBDD.Helpers
{
    public class ScreenshotHelper
    {
        private readonly IWebDriver driver;

        public ScreenshotHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TakeScreenshot(string screenshotFileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotFileName + ".png"); // sempre PNG
        }
    }
}
