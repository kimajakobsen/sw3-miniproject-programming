using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIP.Helpers;

namespace MIP
{
    class Cart
    {

        private List<OrderLine> _orderList;
        static private Cart _cart;

        private Cart()
        {
            _orderList = new List<OrderLine>();
        }

        static public Cart GetCart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new Cart();
                }
                return _cart;
            }
        }

        //Function that returns the orderList
        public List<OrderLine> GetOrderList()
        {
            return _orderList;
        }


        //Fuction for adding to cart
        public void AddToCart(int number, int productcode)
        {
            //Boolean to check if the product is already in cart
            Boolean addNew = true;
            //check if product code already exists

            //Search for product
            for (int i = 0; i < _orderList.Count; i++)
            {
                //If product already exists then just add a extra order
                if (_orderList[i].Productcode == productcode)
                {
                    _orderList[i].Number += number;
                    //Set addNew to false so we dont add a new product
                    addNew = false;
                }
            }

            //If addNew is true, this product do not exists in the cart
            if (addNew == true)
            {
                //Insert the number and productcode
                OrderLine order = new OrderLine(number, productcode);
                _orderList.Add(order);
            }

        }

        //Function to remove from cart
        public void RemoveFromCart(int number, int productcode)
        {
            for (int i = 0; i < _orderList.Count; i++)
            {
                //If product exists then remove number of items
                if (_orderList[i].Productcode == productcode)
                {
                    //check if Number is bigger then 0 and the current number of product is smaller then Number
                    if (number > 0 && _orderList[i].Number > number)
                    {
                        //Remove Number from number of product
                        _orderList[i].Number -= number;
                    }
                    //else if Number equals null or equals the current number of product

                    else if (_orderList[i].Number <= number)
                    {
                        //Remove all number of product
                        _orderList.RemoveAt(i);
                    }
                }
            }
        }

        //Function that returns a string with number of products, manufacture, name, storagesize, price, delivery and totalprice
        public string CartToPrint()
        {
            //Boolean to check if any items in orderList exists in ProductList
            Boolean empty = true;
            string _show = "";
            string _capacity = "";
            double totalprice = 0;
            //For loop to find product info by comparing orderList productcode and ProductList productcode
            for (int i = 0; i < _orderList.Count; i++)
            {
                for (int j = 0; j < Parser.ProductList.Count; j++)
                {
                    if (_orderList[i].Productcode == Parser.ProductList[j].ProductCode)
                    {
                        //Match found, and empty is set to false.
                        empty = false;
                        try
                        {   //Rounding storage size GB / TB
                            StorageUnit productUnit = Parser.ProductList[j] as StorageUnit;

                            //If storage is smaller then 1024 return stage in GB
                            if (productUnit.Storage < 1024)
                            {
                                _capacity = productUnit.Storage.ToString() + " GB";
                            }
                                //Else round to TB
                            else
                            {
                                // Storage divided by 1024 to convert into TB
                                double cap = Convert.ToDouble(productUnit.Storage) / 1024;
                                //Round Storage with 1 decimal and add TB at the end of it
                                cap = Math.Round(cap, 1);
                                _capacity = cap.ToString() + " TB";
                            }
                        }
                        catch { }
                        //Prepare the number of product
                        String numberofproduct = _orderList[i].Number.ToString() + ". ";
                        //price for the selected product * number of the product
                        Double price = Parser.ProductList[j].Price * _orderList[i].Number;
                        //Prepare the manufactor
                        String manufactor = Parser.ProductList[j].Manufacturer.Name + " ";
                        //Prepare the name
                        String name = Parser.ProductList[j].Name + " ";
                        //Combines number of product, manufactor, name and storage
                        String print = numberofproduct + manufactor + name + _capacity;
                        //Adds the price to the total price
                        totalprice += price;

                        //Calls truncate to add "..." if the string is over 35 characters
                        print = print.Truncate(35);
                        //Converts price to string with two decimals
                        String strprice = price.ToString("0.00") + " kr.";
                        //Length of price
                        int charnum = print.Length + strprice.Length;
                        //Defines string length for the "_"
                        charnum = 50 - charnum;
                        string underscore = "";
                        //Runs a for loop to craete the "_" string
                        for (int k = 0; k <= charnum; k++)
                        {
                            underscore += "_";   
                        }
                        //Combines all the stings
                        _show += print+underscore+strprice+"\n";
                    }
                }
            }
            //if the orderList count equals 0, there are no items in the cart
            if (_orderList.Count == 0)
            {
<<<<<<< .mine
                //Returns a msg to info user that there are no items in the cart
                return "There is no items in your cart";
=======
                _show = "There are no items in your cart";
>>>>>>> .r104
            } 
            else
            {
                //Find the price for delivery
                decimal delivery;
                if (totalprice < 250)
                {
                    delivery = 50;
                    totalprice += 50;
                }
                else if (totalprice >= 250 && totalprice <= 500)
                {
                    delivery = 25;
                    totalprice += 25;
                }
                else 
                {
                    delivery = 0;
                    totalprice += 0;
                }
                //Converts delivery to a string with two decimals
                String strdelivery = delivery.ToString("0.00") + " kr."
                //Find how long the "_" should be, the "8" is for "delivery"
                int strnumdelivery = 50 - (strdelivery.Length + 8);
                string underscore = "";
                //For loop to create "_" string
                for (int k = 0; k <= strnumdelivery; k++)
                {
                    underscore += "_";
                }
                //Add the delivery string to the rest of the cart print
                _show += "Delivery" + underscore + strdelivery+"\n";

                //Converts the total to a string with 2 decimals
                String strtotal = totalprice.ToString("0.00") + " kr.";
                //Find how long the "_" should be, the "5" is for "total"
                int strnum = 50 - (strtotal.Length + 5);
                underscore = "";
                //Creating the "_" string
                for (int k = 0; k <= strnum; k++)
                {
                    underscore += "_";
                }
                //Adds total the the rest of cart print
                _show += "Total" + underscore + strtotal;
                //If empty equals true, no items in the card matched ProductList productcodes
                if (empty == true)
                {
<<<<<<< .mine
                    //returns a string of nothing;
                    return "";
=======
                    _show = "There are no items in your cart";
                    return _show;
>>>>>>> .r104
                }else{
                    //Empty equals false, and therefor it will return the cart print
                    return _show;
                }
            }
        }
        /*
        public void PrintCart()
        {
            string _show;
            string _capacity = "";
            _show = "";
            decimal totalprice = 0;
            for (int i = 0; i < _orderList.Count; i++)
            {
                for (int j = 0; j < Parser.ProductList.Count; j++)
                {
                    if (_orderList[i].Productcode == Parser.ProductList[j].ProductCode)
                    {
                        try
                        {
                            StorageUnit productUnit = Parser.ProductList[j] as StorageUnit;

                            if (productUnit.Storage < 1024)
                            {
                                _capacity = productUnit.Storage.ToString() + " GB";
                            }
                            else
                            {
                                double cap = Convert.ToDouble(productUnit.Storage) / 1024;
                                cap = Math.Round(cap, 1);
                                _capacity = cap.ToString() + " TB";
                            }
                        }
                        catch { }

                        String numberofproduct = _orderList[i].Number.ToString() + ". ";
                        Double tempprice = Parser.ProductList[j].Price * _orderList[i].Number;
                        decimal price = Convert.ToDecimal(tempprice);
                        String manufactor = Parser.ProductList[j].Manufacturer.Name + " ";
                        String name = Parser.ProductList[j].Name + " ";
                        String print = numberofproduct + manufactor + name + _capacity;
                        totalprice += price;

                        print = print.Truncate(35);
                        String strprice = price.ToString("0.00") + " kr.";
                        int charnum = print.Length + strprice.Length;
                        charnum = 50 - charnum;
                        string underscore = "";
                        for (int k = 0; k <= charnum; k++)
                        {
                            underscore += "_";   
                        }
                        _show += print+underscore+strprice+"\n";
                    }
                }
            }
            if (_orderList.Count == 0)
            {
                Console.Write("There are no items in your cart");
            } 
            else
            {
                decimal delivery;
                if (totalprice < 250)
                {
                    delivery = 50;
                    totalprice += 50;
                }
                else if (totalprice >= 250 && totalprice <= 500)
                {
                    delivery = 25;
                    totalprice += 25;
                }
                else 
                {
                    delivery = 0;
                    totalprice += 0;
                }
                String strdelivery = delivery.ToString("0.00") + " kr.";
                //string.Length + length of delivery (8)
                int strnumdelivery = 50 - (strdelivery.Length + 8);
                string underscore = "";
                for (int k = 0; k <= strnumdelivery; k++)
                {
                    underscore += "_";
                }
                _show += "Delivery" + underscore + strdelivery+"\n";

                //string.length + length of "total" (5)
                String strtotal = totalprice.ToString("0.00") + " kr.";
                int strnum = 50 - (strtotal.Length + 5);
                underscore = "";
                for (int k = 0; k <= strnum; k++)
                {
                    underscore += "_";
                }
                _show += "Total" + underscore + strtotal;

                Console.Write(_show);
            }
        }
        //Function to remove all items in cart
        public void Clear()
        {
            //Clearing the list for items
            _orderList.Clear();
        }

        //CheckOut will show whats in the cart and remove all items from the cardList
        public void CheckOut()
        {
            PrintCart();
            Clear();
        }


    
         */
    }
}