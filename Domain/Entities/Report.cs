using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Report
    {
        public int TotalKills { get; set; }
        public List<string> Players { get; set; } = new();
        public Dictionary<string, int> Kills { get; set; } = new();
    }
}
