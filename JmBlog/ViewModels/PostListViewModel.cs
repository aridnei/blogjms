using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JmBlog.ViewModels
{
    public class PostListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime DatePublished { get; set; }
        public string ImageBase64 { get; set; }
        public string Permalink { get; set; }
    }
}
