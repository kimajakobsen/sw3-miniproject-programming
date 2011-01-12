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
                        String strprice = price.ToString() + " kr.";
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
                Console.Write("There is no items in your cart");
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
                String strdelivery = delivery.ToString() + " kr.";
                //string.Length + length of delivery (8)
                int strnumdelivery = 50 - (strdelivery.Length + 8);
                string underscore = "";
                for (int k = 0; k <= strnumdelivery; k++)
                {
                    underscore += "_";
                }
                _show += "Delivery" + underscore + strdelivery+"\n";

                //string.length + length of "total" (5)
                String strtotal = totalprice.ToString() + " kr.";
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

        public void Clear()
        {
            _orderList.Clear();
        }

        //CheckOut will show whats in the cart and remove all items from the cardList
        public void CheckOut()
        {
            PrintCart();
            Clear();
        }


    }
}
