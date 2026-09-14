using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Handler;

namespace RainbowMage.HtmlRenderer
{
    class CustomRequestHandler : RequestHandler
    {
        Renderer _renderer;

        public CustomRequestHandler(Renderer renderer) : base()
        {
            _renderer = renderer;
        }

        protected override void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status, int errorCode, string errorMessage)
        {
            var msg = string.Format(Resources.BrowserCrashed, status + "_" + errorCode + "_" + errorMessage);
            _renderer.Browser_ConsoleMessage(this, new BrowserConsoleLogEventArgs(msg, "internal", 0));

            _renderer.InitBrowser();
            _renderer.BeginRender();
        }
    }
}
