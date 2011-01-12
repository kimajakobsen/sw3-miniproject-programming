using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    /// <summary>
    /// The manufacturer class contains the manufacturer
    /// the manufacturer have two properties Name and Url
    /// </summary>
    class Manufacturer
    {
        private string _name;
        private string _url;
        static private List<string> _names = new List<string>();

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

        /// <summary>
        /// The name of the manufacturer
        /// The name must be unique, not empty and not be null
        /// </summary>
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
                    if (_names.FirstOrDefault(x => x.ToUpper() == value.ToUpper()) == null)
                    {
                        //Previous name removed from list of names
                        _names.Remove(_name);
                        //The name is valid and is inserted into
                        //the private variable
                        _name = value;
                        //New name added to list
                        _names.Add(_name);
                    }
                    else
                    {
                        throw new InvalidOperationException(value + " cannot be assigned as name,"+
                            "it is already assigned to another Manufacturer");
                    }
                }

                return;
            }
        }

        /// <summary>
        /// The url of the manufacturer
        /// The name must start with http://, contain atleast 7 charecters and not be null
        /// </summary>
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

        /// <summary>
        /// When the manufactor need to be printet in the console, this function is called.
        /// This way the manufactures are allwas displayed in the same manner.
        /// </summary>
        /// <returns>A string with the name and url of the manufacturer</returns>
        public string DisplayAsString()
        {
            return Name + " " + "Url: " + Url;
        }


    }
}
