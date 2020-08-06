using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OS2.Models
{
    public class ProData
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int ProcessId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int ProcessArrivalTime { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ProcessBurstTime { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int ProcessPriority { get; set; }
        public int ProcessWaitTime { get; set; }
        public int ProcessTurnaround { get; set; }
        public int ProcessResponse { get; set; }

        
    }
}