using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class StorageUnit : Product
    {

        private int _storage;
        //Constructor that take 4 arguments, use storage argument
        //and sent name, price, and productcode to Product constuctor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="productcode"></param>
        /// <param name="storage"></param>
        public StorageUnit(string name, double price, int productcode, Manufacturer manufacturer, int storage)
            :base(name, price, productcode, manufacturer)
        {
            this._storage = storage;
        }

        public string NeatCapacity
        {
            get
            {
                string store;
                if (Storage >= 1024)
                {
                    store = (decimal.Round((decimal)Storage / 1024,1)).ToString() + " TB";
                }
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
