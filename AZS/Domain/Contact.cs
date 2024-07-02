using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int BaseId { get; set; }
        public int GasStationId { get; set; }
        public Contract(int contractId, int baseId, int gasStationId)
        {
            ContractId = contractId;
            BaseId = baseId;
            GasStationId = gasStationId;
        }
    }
}
