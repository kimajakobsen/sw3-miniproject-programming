using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    /// <summary>
    /// Input can be HDMI, DVI eller VGA.
    /// </summary>
    public static class Input
    {
        //_input list
        static private List<string> _input = new List<string>();
        
        //Functon the add input
        public static void setInput(String inputName)
        {
            _input.Add(inputName);
        }
        //Function to return the _input list
        public static List<string> getInput
        {
            get
            {
                return _input;
            }
        }
    }
}
