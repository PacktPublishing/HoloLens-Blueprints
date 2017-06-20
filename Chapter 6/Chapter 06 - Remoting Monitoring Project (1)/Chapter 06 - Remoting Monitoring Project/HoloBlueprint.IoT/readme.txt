Project 2 - HoloBlueprint IoT Server Side Code

This solution consists of three projects
1. HoloBlueprint.Data - consists of all entities related to building, wings, floor and room
2. HoloBlueprint.Sensors.Simulator - consists of simulated simulator for building sensors, and pushes data to Azure EventHub on periodic interval
3. HoloBlueprint.Sensors.WebAPI - Web API project, reads data from Document DB, and exposes as API

To make it work, make following configuration changes
1. Within HoloBlueprint.Sensors.Simulator\Program.cs file, update following EventHub connection settings,
        private const string EhConnectionString = "[Connection string for Event Hub]";
        private const string EhEntityPath = "[Event Hub Entity Path Name]";

2. Within HoloBlueprint.Sensors.WebAPI\Data\BuildingCreator.cs, update following settings related to DocumentDB,
        private const string EndpointUri = "https://[Name of DocumentDB].documents.azure.com:443/";
        private const string PrimaryKey = "[Primary or Secondary Key of DocumentDB]";
        private const string DatabaseName = "[Database name within DocumentDB]";
        private const string CollectionName = "[Collection name within DocumentDB]";