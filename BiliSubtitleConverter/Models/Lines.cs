using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliSubtitleConverter.Models
{
    public class Lines
    {
        public string content { get; set; }
        public int location { get; set; }
        public double from { get; set; }
        public double to { get; set; }
    }
}
