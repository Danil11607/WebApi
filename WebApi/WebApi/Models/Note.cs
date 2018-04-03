using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }
    }
}
