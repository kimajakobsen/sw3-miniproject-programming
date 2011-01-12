using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class InternalHarddrive : Harddrive
    {
        private EFormFactor _formFactor;

        /// <summary>
        /// Constructor of harddrive
        /// </summary>
        /// <param name="name">The name of the given harddrive</param>
        /// <param name="price">Price of the harddrive</param>
        /// <param name="productCode">The product code of the harddrive</param>
        /// <param name="capacity">The storage space of the harddrive</param>
        /// <param name="rpm">The spin speed of the harddrive</param>
        /// <param name="formFactor">The size of the harddrive</param>
        public InternalHarddrive(string name, double price, int productCode, Manufacturer manufacturer,
            int storage, int rpm, double formFactor)
            : base(name, price, productCode, manufacturer, storage, rpm)
        {
            FormFactor = formFactor;
        }

        /// <summary>
        /// This holds the form factor of the harddrive
        /// It converts between double and EFormFactor
        /// </summary>
        public double FormFactor
        {
            get
            {
                //The EFormFactor holds the form factor
                //in centi-inches
                return ((double)_formFactor)/100;
            }

            set
            {

                if (Enum.IsDefined(typeof(EFormFactor), (int)(value * 100)))
                {
                    _formFactor = (EFormFactor)(value * 100);
                }
                else
                {
                    throw new InvalidOperationException("Unable to assign " + value + " to a form factor value");
                }

                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        override public string ToSearchResultString()
        {
            return Manufacturer.Name + " " + Name + " " + Rpm + " rpm " + NeatCapacity + " " +
                FormFactor + "\" " + Price + " kr.";
        }
    }
}
