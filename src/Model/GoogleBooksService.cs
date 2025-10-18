using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public static class GoogleBooksService
    {
        private static readonly HttpClient _http = new HttpClient();

        public class GoogleBook
        {
            public string Title { get; set; } = "";
            public string Author { get; set; } = "";
            public string Isbn { get; set; } = "";
        }

        public static async Task<List<GoogleBook>> SearchAsync(string query)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(query)}&maxResults=10";

            using var res = await _http.GetAsync(url);
            res.EnsureSuccessStatusCode();

            using var s = await res.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(s);

            var list = new List<GoogleBook>();

            if (!doc.RootElement.TryGetProperty("items", out var items)) return list;

            foreach (var item in items.EnumerateArray())
            {
                if (!item.TryGetProperty("volumeInfo", out var info)) continue;

                var title = info.TryGetProperty("title", out var t) ? t.GetString() ?? "" : "";
                string author = "";
                if (info.TryGetProperty("authors", out var a) && a.ValueKind == JsonValueKind.Array)
                {
                    foreach (var aa in a.EnumerateArray()) { author = aa.GetString() ?? ""; break; }
                }

                string isbn = "";
                if (info.TryGetProperty("industryIdentifiers", out var ids) && ids.ValueKind == JsonValueKind.Array)
                {
                    foreach (var id in ids.EnumerateArray())
                    {
                        if (id.TryGetProperty("identifier", out var ident))
                        {
                            isbn = ident.GetString() ?? "";
                            break;
                        }
                    }
                }

                list.Add(new GoogleBook { Title = title, Author = author, Isbn = isbn });
            }

            return list;
        }
    }
}
