using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class Manufacturer
    {
        private string _name;
        private string _url;

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
                if (value != null && value.Length >= 7 &&
                    value.Substring(0,6).Equals("http://"))
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
