using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Friend
{
    public class Follow
    {
        [Key]
        public int Id { get; set; }

        public int RequesterId { get; set; }

        public string? RequesterUsername { get; set; }

        public int ResponserId { get; set; }

        public string? ResponserUsername { get; set; }

        public bool IsFollow { get; set; }
    }
}
