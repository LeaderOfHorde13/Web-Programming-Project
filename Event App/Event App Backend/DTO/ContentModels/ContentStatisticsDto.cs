using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ContentModels
{
    public class ContentStatisticsDto
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public int ContentId { get; set; }

        public int GuestsId { get; set; }

        public string GuestUsername { get; set; }

        public string Message { get; set; }

        public bool IsChecked { get; set; }

        public bool IsLiked { get; set; }

        public bool IsShared { get; set; }

        public bool IsComment { get; set; }

        public bool IsParticipate { get; set; }

        public string? Comment { get; set; }
    }
}
