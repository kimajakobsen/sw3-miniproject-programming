using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class Harddrive : StorageUnit
    {

        private RPM _rpm;


        public Harddrive(string name, double price, int productcode, int storage, int RPM)
            : base(name, price, productcode, storage)
        {




        }
    }
}
