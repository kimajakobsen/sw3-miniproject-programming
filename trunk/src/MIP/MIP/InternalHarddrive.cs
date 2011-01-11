using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class InternalHarddrive : Harddrive
    {
        private EFormFactor _formFactor;

        public InternalHarddrive(string name, double price, int productCode, int storage, RPM rpm, double formFactor)
            : base(name, price, productCode, storage, rpm)
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
                return (double)_formFactor;
            }

            set
            {
                try
                {
                    _formFactor = (EFormFactor)value;
                }
                catch (InvalidCastException)
                { 
                }

                return;
            }
        }
    }
}
