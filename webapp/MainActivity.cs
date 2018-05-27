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
using SQLite;

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
            webView.SetWebViewClient(new Js_Api(get_autocomplete_db()));

            String content = load_asset_str("RazorView.html");
            webView.LoadDataWithBaseURL("file:///android_asset/", content, "text/html", "UTF-8", null);
        }

        public string load_asset_str(string asset_path)
        {
            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open(asset_path)))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }

        private SQLiteConnection get_autocomplete_db()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(path, "database.db");

            if (!File.Exists(db_path))
            {
                Stream myInput = Assets.Open("database.db");
                Stream myOutput = new FileStream(db_path, FileMode.OpenOrCreate);
                byte[] buffer = new byte[1024];
                int b = buffer.Length;
                int length;

                while ((length = myInput.Read(buffer, 0, b)) > 0)
                    myOutput.Write(buffer, 0, length);

                myOutput.Flush();
                myOutput.Close();
                myInput.Close();
            }
            return new SQLiteConnection(db_path);
        }
    }
}

