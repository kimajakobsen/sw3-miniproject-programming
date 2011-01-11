using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class Harddrive : StorageUnit
    {

        private ERPM _rpm;

        /// <summary>
        /// The round per minut constructor
        /// </summary>
        /// <param name="name">The name of the product</param>
        /// <param name="price">The price of the product</param>
        /// <param name="storage">The amound of storage in GB</param>
        /// <param name="RPM">Rounds per minut</param>
        /// <param name="productcode">The productcode of the product</param>

        public Harddrive(string name, double price, int productcode, Manufacturer manufacturer, int storage, int RPM)
            : base(name, price, productcode, manufacturer, storage)
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
                    if (Enum.IsDefined(typeof(ERPM), value))
                        _rpm = (ERPM)value;
                }
            }
    }  
}
