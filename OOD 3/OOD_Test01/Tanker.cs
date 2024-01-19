using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
    class Tanker : Vehicle
    {
        private int liquidCapacity;
        private string liquidType;

        public Tanker(string make, string model, int weight, string regNo, int liquidCapacity, string liquidType)
            : base(make, model, weight, regNo)
        {
            this.liquidCapacity = liquidCapacity;
            this.liquidType = liquidType;
        }

        public override string GetLiquidCapacity()
        {
            return (this.liquidCapacity.ToString());
        }

        public override string GetLiquidType()
        {
            return (this.liquidType);
        }
    }
}
