using System;
using System.Windows;

namespace WpfWebBrowserDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webBrowser.Source = new Uri("http://www.cnblogs.com/cielosun");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string uri = textBox.Text;
            if (!(uri.Contains("http://") || uri.Contains("https://")))
            {
                uri = "http://" + uri;
                textBox.Text = uri;
            }
            webBrowser.Source = new Uri(uri);
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Print();
        }

        private void ButtonJS_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.AddJavaScriptElement("function GoToBaidu(){window.location.href=\"http://www.baidu.com\"; }");
            webBrowser.InvokeScript("GoToBaidu");
        }
    }
}