using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBoard.Models
{
    public class BoardViewModel
    {
        public Board Board { get; set; }
        public List<Reply> Replies { get; set; }
        public Reply Reply { get; set; }
    }
}