using System;
using System.Collections.Generic;

namespace HoloBlueprint.Data
{
    public class Building
    {
        public string BuildingName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public List<Wing> Wings { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}