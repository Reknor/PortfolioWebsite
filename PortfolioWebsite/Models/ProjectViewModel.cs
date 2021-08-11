using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BartlomiejJagielloLab4ZadDom.Models
{
    // Stores information about project
    public class ProjectViewModel
    {
        public ProjectViewModel(string name, string description, List<string> photos)
        {
            Name = name;
            Description = description;
            Photos = photos.ToArray();
            Comments = new List<Comment>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        // Requires at least 1 photo
        public string[] Photos { get; set; }

        public List<Comment> Comments { get; set; }

        public void addComment(string nick, string message)
        {
            Comment comment = new Comment(nick, message);
            Comments.Add(comment);
        }

        public class Comment
        {
            public Comment()
            {

            }

            public Comment(string nick, string message)
            {
                Nick = nick;
                Message = message;
            }

            public string Nick { get; set; }

            public string Message { get; set; }
        }
    }
}
