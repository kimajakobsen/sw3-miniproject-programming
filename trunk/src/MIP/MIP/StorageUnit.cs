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
        public StorageUnit(string name, double price, int productcode, int storage)
            :base(name, price, productcode)
        {
            this._storage = storage;
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
