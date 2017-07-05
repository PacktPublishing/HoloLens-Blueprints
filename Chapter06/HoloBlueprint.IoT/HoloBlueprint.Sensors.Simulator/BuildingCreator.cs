namespace HoloBlueprint.Sensors.Simulator
{
    using HoloBlueprint.Data;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Building Creator
    /// </summary>
    public static class BuildingCreator
    {
        /// <summary>
        /// Loads the buildings data.
        /// </summary>
        /// <param name="buildingNumber">The building number.</param>
        /// <returns>Load simulator data.</returns>
        public static Building LoadBuildingsData(int buildingNumber)
        {
            Random rnd = new Random();

            Room b1w1f0r1 = new Room { IsFire = false, IsSmoke = false, RoomNumber = "B1-W1-001", Temperature = 24 };
            Room b1w1f1r1 = new Room { IsFire = false, IsSmoke = false, RoomNumber = "B1-W1-101", Temperature = 24 };
            Room b1w1f2r1 = new Room { IsFire = false, IsSmoke = false, RoomNumber = "B1-W1-201", Temperature = 28 };
            Room b1w1f3r1 = new Room { IsFire = false, IsSmoke = false, RoomNumber = "B1-W1-301", Temperature = 24 };
            
            Floor b1w1f0 = new Floor { FloorNumber = "B1-W1-F0" };
            b1w1f0.Rooms = new List<Room>();
            b1w1f0.Rooms.Add(b1w1f0r1);

            Floor b1w1f1 = new Floor { FloorNumber = "B1-W1-F1" };
            b1w1f1.Rooms = new List<Room>();
            b1w1f1.Rooms.Add(b1w1f1r1);
            
            Floor b1w1f2 = new Floor { FloorNumber = "B1-W1-F2" };
            b1w1f2.Rooms = new List<Room>();
            b1w1f2.Rooms.Add(b1w1f2r1);
            
            Floor b1w1f3 = new Floor { FloorNumber = "B1-W1-F3" };
            b1w1f3.Rooms = new List<Room>();
            b1w1f3.Rooms.Add(b1w1f3r1);
            
            Wing b1w1 = new Wing { WingName = "B1-W1" };
            b1w1.Floors = new List<Floor>();
            b1w1.Floors.Add(b1w1f0);
            b1w1.Floors.Add(b1w1f1);
            b1w1.Floors.Add(b1w1f2);
            b1w1.Floors.Add(b1w1f3);

            Room b1w2f0r1 = new Room { IsFire = false, IsSmoke = false, RoomNumber = "B1-W2-001", Temperature = 24 };
            Room b1w2f1r1 = new Room { IsFire = false, IsSmoke = false, RoomNumber = "B1-W2-101", Temperature = 24 };
            Room b1w2f2r1 = new Room { IsFire = false, IsSmoke = false, RoomNumber = "B1-W2-201", Temperature = 24 };
            Room b1w2f3r1 = new Room { IsFire = true, IsSmoke = true, RoomNumber = "B1-W2-301", Temperature = 36 };
            Room b1w2f4r1 = new Room { IsFire = false, IsSmoke = true, RoomNumber = "B1-W2-401", Temperature = 38 };

            Floor b1w2f0 = new Floor { FloorNumber = "B1-W2-F0" };
            b1w2f0.Rooms = new List<Room>();
            b1w2f0.Rooms.Add(b1w2f0r1);

            Floor b1w2f1 = new Floor { FloorNumber = "B1-W2-F1" };
            b1w2f1.Rooms = new List<Room>();
            b1w2f1.Rooms.Add(b1w2f1r1);
            
            Floor b1w2f2 = new Floor { FloorNumber = "B1-W2-F2" };
            b1w2f2.Rooms = new List<Room>();
            b1w2f2.Rooms.Add(b1w2f2r1);

            Floor b1w2f3 = new Floor { FloorNumber = "B1-W2-F3" };
            b1w2f3.Rooms = new List<Room>();
            b1w2f3.Rooms.Add(b1w2f3r1);

            Floor b1w2f4 = new Floor { FloorNumber = "B1-W2-F4" };
            b1w2f4.Rooms = new List<Room>();
            b1w2f4.Rooms.Add(b1w2f4r1);

            Wing b1w2 = new Wing { WingName = "B1-W2" };
            b1w2.Floors = new List<Floor>();
            b1w2.Floors.Add(b1w2f0);
            b1w2.Floors.Add(b1w2f1);
            b1w2.Floors.Add(b1w2f2);
            b1w2.Floors.Add(b1w2f3);
            b1w2.Floors.Add(b1w2f4);

            Building building = new Building { Id = "12345", Address = "1123, Hitech City, Hyderabad, India - 500032", BuildingName = "XyZ Inc.", TimeStamp = DateTime.Now };
            building.Wings = new List<Wing>();
            building.Wings.Add(b1w1);
            building.Wings.Add(b1w2);

            return building;
        }
    }
}