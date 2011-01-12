using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class FlashStorage : StorageUnit
    {
        private bool _secureUSB;

        /// <summary>
        /// Constructor of Flash
        /// </summary>
        /// <param name="name">The name of the given flash</param>
        /// <param name="price">Price of the flash</param>
        /// <param name="productCode">The product code of the flash</param>
        /// <param name="capacity">The storage space of the flash</param>
        /// <param name="secure">Bool indicating if the flash is encrypted</param>
        public FlashStorage(string name, double price, int productCode, Manufacturer manufacturer, int capacity, bool secure)
            : base(name, price, productCode, manufacturer, capacity)
        {
            SecureUSB = secure;
        }

        //Boolean indicating whether the flash unit is encrypted or not
        public bool SecureUSB
        {
            get
            {
                return _secureUSB;
            }

            set
            {
                _secureUSB = value;
            }
        }        
        //Return string with FlashStorage info
        /// <summary>
        /// When a Flash drive needs to be printet in the console, this function is called.
        /// This way all the Flash drive are allwas displayed in the same manner.
        /// </summary>
        /// <returns>Returns a string with all the properties of the flash drive</returns>
        override public string ToSearchResultString()
        {
            string encryption;
            if (SecureUSB) //if it is true
            {
                encryption = "is secured";
            }
            else
            { 
                encryption = "is not secured";
            }

            return Manufacturer.Name + " " + Name + " " + encryption + " " + NeatCapacity + " " +
                " " + Price + " kr.";
        }
    }
}
