using System;
using System.Windows;
using System.Windows.Input;

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string uri = textBox.Text;
            if (!(uri.Contains("http://") || uri.Contains("https://")))
            {
                uri = "http://" + uri;
                textBox.Text = uri;
            }
            webBrowser.Source = new Uri(uri);
        }

        private void WebBrowser_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Print();
        }
    }
}