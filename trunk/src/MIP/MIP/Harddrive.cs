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
        /// The round per minut constructor
        /// </summary>
        /// <param name="name">The name of the product</param>
        /// <param name="price">The price of the product</param>
        /// <param name="name">The name of the product</param>
        /// <param name="price">The price of the product</param>
        /// <param name="productcode">The productcode of the product</param>

        public Harddrive(string name, double price, int productcode, int storage, int RPM)
            : base(name, price, productcode, storage)
        {
        }
            /// <summary>
            /// This contains the round per minut (RPM)
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
