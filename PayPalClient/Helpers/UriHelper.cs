using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace PayPalClient.Helpers
{
    public static class UriHelper
    {
        public static Uri ExtendQuery(this Uri uri, IDictionary<string, string> values)
        {
            var baseUrl = uri.ToString();
            var queryString = string.Empty;
            if (baseUrl.Contains("?"))
            {
                var urlSplit = baseUrl.Split('?');
                baseUrl = urlSplit[0];
                queryString = urlSplit.Length > 1 ? urlSplit[1] : string.Empty;
            }
            NameValueCollection queryCollection = HttpUtility.ParseQueryString(queryString);
            foreach (var kvp in values ?? new Dictionary<string, string>())
            {
                queryCollection[kvp.Key] = kvp.Value;
            }
            var uriKind = uri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative;
            return queryCollection.Count == 0
              ? new Uri(baseUrl, uriKind)
              : new Uri(string.Format("{0}?{1}", baseUrl, queryCollection), uriKind);
        }
    }
}
