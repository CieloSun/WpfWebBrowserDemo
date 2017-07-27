using mshtml;
using System.Reflection;
using System.Windows.Controls;

namespace WpfWebBrowserDemo
{
    public static class WebBrowserExtensions
    {
        public static void ScriptErrorsSuppressed(this WebBrowser webBrowser, bool hide = true)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;

            object objComWebBrowser = fiComWebBrowser.GetValue(webBrowser);
            if (objComWebBrowser == null) return;

            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { hide });
        }
        public static void AddJavaScriptElement(this WebBrowser webBrowser, string javaScriptString, string className = "")
        {
            if (webBrowser.Document is HTMLDocument doc)
            {
                var element = doc.createElement("script") as HTMLScriptElement;
                if (className != "") element.className = className;
                element.type = "text/javascript";
                element.text = javaScriptString;
                var nodes = doc.getElementsByTagName("head");

                foreach (var node in nodes)
                {
                    (node as HTMLHeadElement).appendChild(element as IHTMLDOMNode);
                }
            }
        }
        public static void Print(this WebBrowser webBrowser)
        {
            (webBrowser.Document as HTMLDocument).execCommand("Print");
        }
    }
}
