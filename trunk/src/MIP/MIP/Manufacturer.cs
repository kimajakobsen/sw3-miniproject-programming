using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    /// <summary>
    /// The manufacturer class holds a manufacturer of products
    /// It contains a Name and a Url
    /// </summary>
    class Manufacturer
    {
        private string _name;
        private string _url;

        /// <summary>
        /// Constructor of manufacturer
        /// </summary>
        /// <param name="name">Name of the manufacturer</param>
        /// <param name="url">URL of the manufacturers homepage</param>
        public Manufacturer(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                //The new value may not be an empty string
                if (value != null && value != "")
                {
                    //The name is valid and is inserted into
                    //the private variable
                    _name = value;
                }

                return;
            }
        }

        public string Url
        {
            get
            {
                return _url;
            }

            set
            {
                //The url must start with http://
                if (value != null && value.Length >= 7 &&
                    value.StartsWith("http://"))
                {
                    //The url is valid and is inserted into
                    //the private variable
                    _url = value;
                }

                return;
            }
        }
    }
}
