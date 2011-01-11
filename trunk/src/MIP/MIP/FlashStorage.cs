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
        public FlashStorage(string name, double price, int productCode, int capacity, bool secure)
            : base(name, price, productCode, capacity)
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
    }
}
