using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ParseLogResult
    {
        public Dictionary<string, Report> Games { get; set; }
    }
}
