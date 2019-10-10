using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WatchParty {
    class Masteranime : Website {
        public Masteranime() {
            Console.WriteLine("masteranime class");
        }

        public override void StartBrowser() {
            browser = new Browser(Settings.Default.MasteranimeUrl);
            if (Settings.Default.animeTitle.Length != 0)
            {
                Thread.Sleep(10000);
                browser.browser_.FindElement(By.Id("keyword")).SendKeys(Settings.Default.animeTitle);
                browser.browser_.FindElement(By.ClassName("btn")).Click();
                Thread.Sleep(3500);
                IList<IWebElement> titles = browser.browser_.FindElements(By.ClassName("cover"));
                Console.WriteLine(titles.Count);
                if (titles.Count == 1)
                {
                    titles[0].Click();
                    Thread.Sleep(5000);
                    IList<IWebElement> eps = browser.browser_.FindElements(By.ClassName("title"));
                    Actions actions = new Actions(browser.browser_);
                    actions.MoveToElement(eps[eps.Count - 1]);
                    Thread.Sleep(3000);
                    eps[eps.Count - 1].Click();
                }

            }
            System.Threading.Thread.Sleep(7000);
            
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
