using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WatchParty {
    class Masteranime : Website {
        public Masteranime() {
            Console.WriteLine("masteranime class");
        }

        public override void StartBrowser() {
            browser = new Browser(Settings.Default.MasteranimeUrl);
        }

        public override void StopBrowser() {
            browser.StopBrowser();
        }

        public override string GetCurrentUrl() {
            return browser.GetUrl();
        }

        public override string GetSeriesTitle() {
            IWebElement title = browser.browser_.FindElement(By.CssSelector("div[class='row anime-info']")).FindElement(By.TagName("h1")).FindElement(By.TagName("a"));
            return title.Text;
        }

        public override int GetEpisodeNumber() {
            string episodeNumberString = browser.browser_.FindElement(By.CssSelector("div[class='row anime-info']")).FindElement(By.TagName("h2")).Text;
            episodeNumberString = episodeNumberString.Substring(8, episodeNumberString.Length - 8);
            Int32.TryParse(episodeNumberString, out int episodeNumber);
            return episodeNumber;
        }

        public override string GetEpisodeTitle() {
            return "";
        }

        public override string GetNextEpisodeUrl() {
            throw new NotImplementedException();
        }

        public override string GetPrevEpisodeUrl() {
            throw new NotImplementedException();
        }

        public override string GetCurrentTime() {
            IWebElement elapsedTime = browser.browser_.FindElement(By.CssSelector("div[class='jw-icon jw-icon-inline jw-text jw-reset jw-text-elapsed']"));
            return elapsedTime.Text;
        }

        public override string GetRemainingTime() {
            IWebElement duration = browser.browser_.FindElement(By.CssSelector("div[class='jw-icon jw-icon-inline jw-text jw-reset jw-text-duration']"));
            return duration.Text;
        }
    }
}
