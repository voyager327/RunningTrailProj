using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Running_Trails.Models
{
    public class Runner
    {
        [Key]
        public int RunnerId { get; set; }
        public string SearchRunningTrailsByLocation { get; set; }
        public string SearchRunningTrailsByDifficultyLevel { get; set; } // Easy, Easy to Moderate, Moderate to Difficult
        public int SearchRunningTrailsByTotalDistance { get; set; }
        public string SearchRunningGroupByArea { get; set; }
        

    }
}
