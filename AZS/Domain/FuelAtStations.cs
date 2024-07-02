using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FuelAtStation
    {
        public int Id { get; set; }
        public int GasStationId { get; set; }
        public string FuelType { get; set; }
        public int AvailableQuantity { get; set; }
        public double PricePerLiter { get; set; }

        public FuelAtStation(int id, int gasStationId, string fuelType, int availableQuantity, double pricePerLiter)
        {
            Id = id;
            GasStationId = gasStationId;
            FuelType = fuelType;
            AvailableQuantity = availableQuantity;
            PricePerLiter = pricePerLiter;
        }
    }
}
