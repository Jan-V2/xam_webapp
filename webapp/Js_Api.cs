using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using SQLite;
using Antlr4.StringTemplate;

namespace webapp
{
    class Js_Api : WebViewClient
    {
        private SQLiteConnection autocomplete_db;

        public Js_Api(SQLiteConnection autocomplete_db)
        {
            this.autocomplete_db = autocomplete_db;
        }

        public override bool ShouldOverrideUrlLoading(WebView webView, string url)
        {
            if (url.StartsWith("hybrid:"))
            {
                // This handler will treat everything between the protocol and "?"
                // as the method name.  The querystring has all of the parameters.
                url = url.Substring("hybrid:".Length);
                if (url.StartsWith("test:"))
                {
                    url = url.Substring("test:".Length);
                    if (url == "sqlite")
                    {
                        sqlite_test(webView);
                    }

                }
            }
            sqlite_test(webView);


            return true;
        }

        private void sqlite_test(WebView webView)
        {
            var query = autocomplete_db.Table<testtable>();
           // var bla = Json_Templates.format_testtable(query);
           // System.Diagnostics.Debug.WriteLine(bla);
            webView.LoadUrl("javascript:" + "api.test.sqlite("+Json_Templates.format_testtable(query)+")");
        }

        public class testtable
        {
            public int test { get; set; }
        }

        static class Json_Templates
        {
            public static string format_testtable(TableQuery<testtable> table)
            {
                var templ =
                @"
                {
                    test: <int>
                },
                ";
                var output = "[";
                foreach (var item in table)
                {
                    var bla = new Template(templ);
                    bla.Add("int", item.test);
                    output += bla.Render();
                }
                output+= "]";
                return output;
            }
        }
    }
}