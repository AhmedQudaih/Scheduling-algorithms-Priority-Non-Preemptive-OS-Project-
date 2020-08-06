using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OS2.Models
{
    public class Process
    {
        
        public List<ProData> ProList { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfProcess { get; set; }
        public int AverageWaitTime { get; set; }
        public int AverageTurnaroundTime { get; set; }
        public int AverageResponseTime { get; set; }
    }
}