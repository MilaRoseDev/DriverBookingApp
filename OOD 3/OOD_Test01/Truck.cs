using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
        class Truck : Vehicle
    {
        public int cargoCapacity;

        public Truck(string make, string model, int weight, string regNo, int cargoCapacity) : base(make,model,weight,regNo)
        {
            this.cargoCapacity = cargoCapacity;
        }

        public override string GetCargoCapacity()
        {
            return (this.cargoCapacity.ToString());
        }
    }
}
