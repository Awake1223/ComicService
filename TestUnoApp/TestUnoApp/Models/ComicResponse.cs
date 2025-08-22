using System;
using System.Collections.Generic;

namespace TestUnoApp.Models
{
    public class ComicRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new List<string>();
    }

    public class ComicResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new List<string>();
    }
}
