using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class OrderLine
    {
        private int _number;
        private int _productcode;
        //Constructor for OrderLine
        //Orderline is used for Cart class to store the cart info
        public OrderLine(int number, int productcode)
        {
            Number = number;
            Productcode = productcode;
        }
        //Proberty for Number
        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                if (value != null || value > 0)
                {
                    _number = value;
                }
                return;
            }
        }
        //Proberty for ProdcutCode
        public int Productcode
        {
            get
            {
                return _productcode;
            }

            set
            {
                if (value != null)
                {
                    _productcode = value;
                }
                return;
            }
        }
    }
}
