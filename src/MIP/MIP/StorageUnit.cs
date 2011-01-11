using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class StorageUnit : Product
    {
        private int _storage;
        
        public StorageUnit(int storage)
        {
            _storage = storage;
        }

        public int getStorage()
        {
            return _storage;
        }
    }
}
