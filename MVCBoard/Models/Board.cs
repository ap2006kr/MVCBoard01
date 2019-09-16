using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBoard.Models
{
    public class Board
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedTime { get; set; }
        public ApplicationUser Creater { get; set; }
    }

    public class Reply
    {
        public int Id { get; set; }
        public ApplicationUser Replier { get; set; }
        public string Content { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedTime { get; set; }
        public int BoardId { get; set; }
    }
}
