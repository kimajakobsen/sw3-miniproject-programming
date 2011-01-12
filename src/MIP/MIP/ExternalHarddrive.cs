using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class ExternalHarddrive : Harddrive
    {
        private double _height;
        private double _width;
        private double _depth;
        //Constructor for ExternalHarddrive
        //Sets height, width and depth
        //Sends name, price, productcode, storage, RPM to Harddrive
        public ExternalHarddrive(string name, double price, int productcode, Manufacturer manufacturer,
            int storage, int RPM, double height, double width, double depth)
            : base(name, price, productcode, manufacturer, storage, RPM)
        {
            Height = height;
            Width = width;
            Depth = depth;
        }

        //Getter and Setter for Height
        public double Height
        {
            get
            {
                //Return height
                return _height;
            }

            set
            {
                //Check if height is bigger then 0
                if (value > 0)
                {
                    //If height is bigger then 0, the height will be set to the value
                    _height = value;
                }
                return;
            }
        }

        //Getter and Setter for Width
        public double Width
        {
            get
            {   
                //Return width
                return _width;
            }

            set
            {
                //Check if width is bigger then 0
                if (value > 0)
                {
                    //If width is bigger then 0, the width will be set to the value
                    _width = value;
                }
                return;
            }
        }

        //Getter and Setter for Depth
        public double Depth
        {
            get
            {
                //Return depth
                return _depth;
            }

            set
            {
                //Check if depth is bigger then 0
                if(value > 0)
                {
                    //If depth is bigger then 0, the depth will be set to the value
                    _depth = value;
                }
                return;
            }
        }

        /// <summary>
        /// When a ExternalHarddrive is printet in the console, this function is called.
        /// This way all the External harddrives are allwas displayed in the same manner.
        /// </summary>
        /// <returns>Returns a string with all the properties of the external hardrive</returns>
        override public string ToSearchResultString()
        { 
            return Manufacturer.Name + " " + Name + " " + Rpm + " rpm " + NeatCapacity + " " +
                Height + "/" + Width + "/" + Depth + " " + Price + " kr.";
        }
    }
}
