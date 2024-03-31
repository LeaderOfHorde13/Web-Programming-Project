using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ContentModels
{
    public class ContentComment
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int UsernameId { get; set; }

        public string Text { get; set; }

        public int ContentId { get; set; }
    }
}
