using System;
using System.Windows.Controls;

namespace View.InteractiveElements
{
    class Logger
    {
        private static TextBox _richTextBox;

        public Logger(TextBox richTextBox)
        {
            _richTextBox = richTextBox;
        }

        public static void AddLog(string message)
        {
            _richTextBox.AppendText(message + "\n");
            _richTextBox.ScrollToEnd();
        }
    }
}
