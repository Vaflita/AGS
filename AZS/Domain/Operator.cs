using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Operator
    {
        public int OperatorId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int BaseId { get; set; }

        public Operator(int operatorId, string name, string password, int baseId)
        {
            OperatorId = operatorId;
            Name = name;
            Password = password;
            BaseId = baseId;
        }
    }
}
