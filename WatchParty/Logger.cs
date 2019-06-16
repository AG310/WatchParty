using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WatchParty {
    class Logger {
        private TextBlock textBlock_;
        public Logger(TextBlock textBlock) {
            textBlock_ = textBlock;
        }

        public void Log(string message) {
            textBlock_.Text += ">" + message + "\n";
            ((ScrollViewer)textBlock_.Parent).ScrollToBottom();
        }
    }
}
