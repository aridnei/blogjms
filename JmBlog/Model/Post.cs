using System;
using System.ComponentModel.DataAnnotations;

namespace JmBlog.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime DateUpdated { get; set; }
        public string UrlImage { get; set; }
        public string PermaLink { get; set; }

        public Post()
        {
            
        }
    }

}