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

        public OrderLine(int number, int productcode)
        {
            Number = number;
            Productcode = productcode;
        }
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
