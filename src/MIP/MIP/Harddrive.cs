using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class Harddrive : StorageUnit
    {

        private RPM _rpm;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="productcode"></param>
        /// <param name="storage"></param>
        /// <param name="RPM"></param>

        public Harddrive(string name, double price, int productcode, int storage, int RPM)
            : base(name, price, productcode, storage)
        {
        }
            /// <summary>
            /// This contains the round per minut
            /// </summary>
            public int Rpm
            {
                get
                {
                    return (int)_rpm;
                }
                set
                {
                    //if the entered value is of the RPM standard, then the value is saved.
                    if (Enum.IsDefined(typeof(RPM), value))
                        _rpm = (RPM)value;
                }
            }
    }  
}
