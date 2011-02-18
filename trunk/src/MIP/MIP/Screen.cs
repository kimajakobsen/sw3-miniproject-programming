using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class Screen : Product
    {

        private string _input1;
        private string _input2;
        private string _input3;
        private int _size;
        //Constructor 1
        //name price productcode size color resolution, manufacturer, input1, input2, input3
        public Screen(string name, double price, int productcode, int size, int color, String resolution, Manufacturer manufacturer, String INPUT1,String INPUT2,String INPUT3)
            : base(name, price, productcode, manufacturer)
        {
            Input1 = INPUT1;
            Input2 = INPUT2;
            Input3 = INPUT3;
            Size = size;
        }
        //Constructor 2
        //name price productcode size color resolution, manufacturer, input1, input2
        public Screen(string name, double price, int productcode, int size, int color, String resolution, Manufacturer manufacturer, String INPUT1, String INPUT2)
            : base(name, price, productcode, manufacturer)
        {
            Input1 = INPUT1;
            Input2 = INPUT2;
            Size = size;
        }
        //Constructor 3
        //name price productcode size color resolution, manufacturer, input1
        public Screen(string name, double price, int productcode, int size, int color, String resolution, Manufacturer manufacturer, String INPUT1)
            : base(name, price, productcode, manufacturer)
        {
            Input1 = INPUT1;
            Size = size;
        }
        //Constructor 4
        //name price productcode size color resolution, manufacturer
        public Screen(string name, double price, int productcode, int size, int color, String resolution, Manufacturer manufacturer)
            : base(name, price, productcode, manufacturer)
        {
            Size = size;
        }
        //Set and get for input1
        public string Input1
        {
            get
            {
                return _input1;
            }

            set
            {
                //only set if input1 is a part of the Input list
                if (Input.getInput.Contains(value))
                {
                    _input1 = Input.getInput.FirstOrDefault(x => x == value);
                }
                else
                {
                    throw new InvalidOperationException(value + " do not exists");
                }
            }
            
        }
        //Set and get for input2
        public string Input2
        {
            get
            {
                return _input2;
            }

            set
            {
                //only set if input2 is a part of the Input list
                if (Input.getInput.Contains(value))
                {
                    _input2 = Input.getInput.FirstOrDefault(x => x == value);
                }
                else
                {
                    throw new InvalidOperationException(value + " do not exists");
                }
            }

        }
        //Set and get for input3
        public string Input3
        {
            get
            {
                return _input3;
            }

            set
            {
                //only set if input3 is a part of the Input list
                if (Input.getInput.Contains(value))
                {
                    _input3 = Input.getInput.FirstOrDefault(x => x == value);
                }
                else
                {
                    throw new InvalidOperationException(value + " do not exists");
                }
            }

        }
        //Set and get for Size
        public int Size
        {
            get
            {
                return _size;
            }

            set 
            {
                //The value need to be bigger then 0
                if (value > 0)
                {
                    _size = value;
                }
                else
                {
                    throw new InvalidOperationException(value + " is not valid, it need to be bigger then 0 and be an integer");
                }
            }
        }


        //Function to display it in the search list
        override public string ToSearchResultString()
        {
            return Manufacturer.Name + " " + Name + " " + Size + "\" " +
                " " + Price + " kr.";
        }
        //The ToString function
        override public string ToPrint()
        {
            return Manufacturer.Name + " " + Name + " " + Size + "\"";
        }


    }
}
