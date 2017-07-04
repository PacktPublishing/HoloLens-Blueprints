using System.Collections.Generic;

namespace HoloBlueprint.Data
{
    public class Floor
    {
        public string FloorNumber { get; set; }
        public List<Room> Rooms { get; set; }
    }
}