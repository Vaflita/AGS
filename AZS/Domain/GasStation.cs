using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GasStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public List<FuelAtStation> FuelAtStation { get; set; }
        public List<int> Contracts { get; set; }


        public GasStation(int id, string name, string adress, string status, List<FuelAtStation> fuelAtStation, List<int> contracts)
        {
            Id = id;
            Name = name;
            Adress = adress;
            Status = status;
            FuelAtStation = fuelAtStation;
            Contracts = contracts;  
        }
    }
}
