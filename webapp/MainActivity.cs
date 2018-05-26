using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Android.OS;
//using webapp.Views;
using webapp.Models;
using System.IO;
using Android.Content.Res;

namespace webapp
{
    [Activity(Label = "webapp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var webView = FindViewById<WebView>(Resource.Id.webView);
            webView.Settings.JavaScriptEnabled = true;

            // Use subclassed WebViewClient to intercept hybrid native calls
            webView.SetWebViewClient(new HybridWebViewClient());

            // Render the view from the type generated from RazorView.cshtml
            var model = new Model1() { Text = "Text goes here" };
            //var template = new RazorView() { Model = model };
            //   var page = template.GenerateString();

            // Load the rendered HTML into the view with a base URL 
            // that points to the root of the bundled Assets folder
            //     webView.LoadDataWithBaseURL("file:///android_asset/", page, "text/html", "UTF-8", null);


            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("RazorView.html")))
            {
                content = sr.ReadToEnd();
            }

            //            var content = @"<!DOCTYPE html>
            //<html>
            //<head>
            //    <meta charset=utf-8>
            //    <meta name=viewport content='width = device - width,initial - scale = 1'>
            //    <link rel=stylesheet href=static/scripts/libs/bs4/bootstrap.min.css>
            //    <script src=static/scripts/libs/jquery-3.3.1.min.js></script>
            //    <script src=static/scripts/libs/lodash.core.js></script>
            //    <script src=static/scripts/libs/vueable.js></script>
            //    <script src=static/scripts/utils.js></script>
            //    <script src=static/scripts/mock_api.js></script>
            //    <title>router</title>
            //    <link href=static/css/app.4259f0544d29d18b1554c221578d6b97.css rel=stylesheet>
            //</head>
            //<body>
            //    <h1 style='text-align: center' id=loading_txt>Loading...</h1><div id=app></div>
            //    <script src=static/scripts/libs/bs4/popper.min.js></script>
            //    <script src=static/scripts/libs/bs4/bootstrap.min.js></script>
            //    <script type=text/javascript src=static/js/manifest.2ae2e69a05c33dfc65f8.js></script>
            //    <script type=text/javascript src=static/js/vendor.7fed9fa7b7ba482410b7.js></script>
            //    <script type=text/javascript src=static/js/app.363005da685dca1d20c0.js></script>
            //</body>
            //</html>";

            webView.LoadDataWithBaseURL("file:///android_asset/", content, "text/html", "UTF-8", null);
        }

        private class HybridWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView webView, string url)
            {

                // If the URL is not our own custom scheme, just let the webView load the URL as usual

                if (url.StartsWith("hybrid:"))
                {
                    // This handler will treat everything between the protocol and "?"
                    // as the method name.  The querystring has all of the parameters.
                    var resources = url.Substring("hybrid:".Length).Split('?');
                    var method = resources[0];
                    var parameters = System.Web.HttpUtility.ParseQueryString(resources[1]);

                    if (method == "UpdateLabel")
                    {
                        var textbox = parameters["textbox"];

                        // Add some text to our string here so that we know something
                        // happened on the native part of the round trip.
                        var prepended = string.Format("C# says \"{0}\"", textbox);

                        // Build some javascript using the C#-modified result
                        var js = string.Format("SetLabelText('{0}');", prepended);

                        webView.LoadUrl("javascript:" + js);
                    }
                }else if (url.StartsWith("backend:"))
                {
                    webView.LoadUrl("javascript:counter_update();");
                }

                return true;
            }
        }
    }
}

