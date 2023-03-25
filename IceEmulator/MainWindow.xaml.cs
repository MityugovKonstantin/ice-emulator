using GUI;
using System;
using System.ComponentModel;
using System.Windows;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace IceEmulator
{
    public partial class MainWindow : Window, IGui
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartStop_Button_Click(object sender, RoutedEventArgs e)
        {
            if (StartStop_Button.Content.ToString() == "СТАРТ")
            {
                Logger_RichTextBox.AppendText($"Двигатель получил команду [{StartStop_Button.Content}]\n");
                StartStop_Button.Content = "СТОП";
            }
            else if (StartStop_Button.Content.ToString() == "СТОП")
            {
                Logger_RichTextBox.AppendText($"Двигатель получил команду [{StartStop_Button.Content}]\n");
                StartStop_Button.Content = "СТАРТ";
            }

            if (StartStop_Button.Content.ToString() == "СТОП")
                Logger_RichTextBox.AppendText($"Делаем вид что всё нормально работает\n");
        }

        private void Logger_RichTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Logger_RichTextBox.ScrollToEnd();
            
           // Logger_RichTextBox.SelectionStart = Logger_RichTextBox.Text.Length;
           // Logger_RichTextBox.ScrollToCaret();
        }
    }
}
