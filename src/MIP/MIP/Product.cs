using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    abstract class Product
    {
        private string _name;
        private double _price;
        private int _productcode;
        private List<int> codeList = new List<int>();

        public Product(string name, double price, int productcode)
        {
            Name = name;
            Price = price;
            ProductCode = productcode;

        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value != null && value != "")
                {
                    _name = value;

                }
            }
        }
        

        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value != null && value >= 0)
                {
                _price = value;
                }
            }  
        }


        internal int ProductCode
        {
            get
            {
                return _productcode;
            }

            set
            {
                if (!codeList.Contains(value))
                {
                    _productcode = value;
                }
            }
        }




    }
}
