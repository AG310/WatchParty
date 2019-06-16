using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WatchParty {
    class Browser {
        public IWebDriver browser_ = new FirefoxDriver();

        public Browser(string url) {

            // Attempt to get url
            browser_.Navigate().GoToUrl(url);
            bool wait = new WebDriverWait(browser_, new TimeSpan(0,0,10)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            // Upon failure, show help page
        }

        // Loads input url in browser
        // Throws an exception if url is bad
        public void ChangeUrl(string url) {
            browser_.Navigate().GoToUrl(url);
        }

        public string GetUrl() {
            return browser_.Url;
        }

        public void StopBrowser() {
            browser_.Quit();
        }

    }
}
