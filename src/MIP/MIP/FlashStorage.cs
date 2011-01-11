using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class FlashStorage : StorageUnit
    {
        private bool _secureUSB;

        public FlashStorage(string name, double price, int productCode, int capacity, bool secure)
            : base(name, price, productCode, capacity)
        {
            SecureUSB = secure;
        }

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
