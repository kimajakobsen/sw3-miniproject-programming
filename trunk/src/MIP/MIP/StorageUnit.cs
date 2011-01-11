using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class StorageUnit : Product
    {
        private int _storage;

        public StorageUnit(string name, double price, int productcode, int storage)
            :base(name, price, productcode)
        {
            this._storage = storage;
        }

        public int Storage
        {
            get
            {
                return _storage;
            }

            set
            {
                if(value > 0 || value != null)
                {
                    _storage = value;
                }
                return;
            }
        }
    }
}
