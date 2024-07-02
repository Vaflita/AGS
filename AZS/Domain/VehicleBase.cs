using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VehicleBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public Operator Operator { get; set; }
        public List<int> Contracts { get; set; }


        public VehicleBase(int id, string name, string adress, List<Vehicle> vehicles, List<int> сontracts, Operator _operator)
        {
            Id = id;
            Name = name;
            Adress = adress;
            Vehicles = vehicles;
            Operator = _operator;
            Contracts = сontracts;
        }
    }
}
