using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer
{
   internal  class WhetherResponse   
    {
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }
    }

    public class TemperatureInfo
    {
        public float Temp { get; set; }
    }
}

