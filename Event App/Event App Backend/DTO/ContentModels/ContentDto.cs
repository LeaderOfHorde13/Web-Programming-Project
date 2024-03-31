using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ContentModels
{
    public class ContentDto
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string OwnerUsername { get; set; }

        public string ContentType { get; set; }

        public string Text { get; set; }

        public string CreatingDate { get; set; }

        public int LikeCounter { get; set; }

        public int CommentCounter { get; set; }

        public int ShareCounter { get; set; }

        public string? StartingDate { get; set; }

        public string? EndingDate { get; set; }

        public string? Address { get; set; }

        public int ParticipantCounter { get; set; }
    }
}
