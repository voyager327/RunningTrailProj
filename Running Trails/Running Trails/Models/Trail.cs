using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Running_Trails.Models
{
    public class Trail
    {
        public int TrailId { get; set; }
        public string TrailName { get; set; }
        public string TrailLocation { get; set; }
        public string TrailDifficultyLevel { get; set; }
        public string TrailTotalDistance { get; set; }
    }
}
