namespace Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string FuelType { get; set; }
        public int CurrentFuelLevel { get; set; }
        public int BaseId { get; set; }


        public Vehicle(int id, string model, string type, string fuelType, int currentFuelLevel, int baseId)
        {
            Id = id;
            Model = model;
            Type = type;
            FuelType = fuelType;
            CurrentFuelLevel = currentFuelLevel;
            BaseId = baseId;
        }
    }
}