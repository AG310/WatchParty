using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchParty {
    abstract class Website {
        protected Browser browser;

        // Start browser
        public abstract void StartBrowser();

        // Stop browser
        public abstract void StopBrowser();

        // Return remaining time in episode (ex 1:30)
        public abstract string GetRemainingTime();

        // Return current time in episode (ex: 10:30)
        public abstract string GetCurrentTime();

        // Return series title
        public abstract string GetSeriesTitle();

        // Return episode title
        public abstract string GetEpisodeTitle();

        // Return episode number
        public abstract int GetEpisodeNumber();

        // Return URL of current episode
        public abstract string GetCurrentUrl();

        // Return URL of next episode if applicable
        // null if none
        public abstract string GetNextEpisodeUrl();

        // Return URL of previous episode if applicable
        // null if none
        public abstract string GetPrevEpisodeUrl();
    }
}
