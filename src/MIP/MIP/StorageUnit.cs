using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class StorageUnit : Product
    {

        private int _storage;
        //Constuctor for StorageUnit, uses storage.
        public StorageUnit(string name, double price, int productcode, Manufacturer manufacturer, int storage)
            :base(name, price, productcode, manufacturer)
        {
            this._storage = storage;
        }

        //Formats the storage TB / GB
        public string NeatCapacity
        {
            get
            {
                string store;
                //If storage is equal or bigger then 1024 it should be formatted as TB
                if (Storage >= 1024)
                {
                    //Devided by 1024 to get GB and then rounded to 1 decimal
                    store = (decimal.Round((decimal)Storage / 1024,1)).ToString() + " TB";
                }
                //Else it should be formatted as GB
                else
                {
                    store = Storage + " GB";
                }

                return store;
            }
        }

        public int Storage
        {
            get
            {
                //Returns the storage
                return _storage;
            }

            set
            {
                /*
                 *Check if the value is bigger then 0 since the storage cannot be 0 or below
                 */
                if (value > 0)
                {   
                    //Sets the value if the if statement is valid
                    _storage = value;
                }
                return;
            }
        }
    }
}
