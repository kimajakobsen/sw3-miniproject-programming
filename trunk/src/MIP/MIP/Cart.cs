using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIP
{
    class Cart
    {
    
        private static List<Cart> cartList = new List<Cart>();
        private string _show;
        private string _capacity;
        private int _number;
        private int _productcode;

        public Cart(int number, int productcode)
        {
            Number = number;
            Productcode = productcode;
        }

        public int Number
        {
            get
            {
                return _number;
            }
            
            set
            {
                if (value != null || value > 0)
                {
                    _number = value;
                }
                return;
            }
        }

        public int Productcode
        {
            get
            {
                return _productcode;
            }
            
            set
            {
                if (value != null)
                {
                    _productcode = value;
                }
                return;
            }
        }

        //Fuction for adding to cart
        public void AddToCart(int number, int productcode)
        {
            //Boolean to check if the product is already in cart
            Boolean addNew = true;
            //check if product code already exists

            //Search for product
            for (int i = 0; i < cartList.Count; i++)
            {
                //If product already exists then just add a extra order
                if (cartList[i].Productcode == productcode)
                {
                    cartList[i].Number += number;
                    //Set addNew to false so we dont add a new product
                    addNew = false;
                }
            }

            //If addNew is true, this product do not exists in the cart
            if (addNew == true)
            {
                //Insert the number and productcode
                Cart order = new Cart(number, productcode);
                cartList.Add(order);
            }

        }

        public void RemoveFromCart(int number, int productcode)
        {
            for (int i = 0; i < cartList.Count; i++)
            {
                //If product exists then remove number of items
                if (cartList[i].Productcode == productcode)
                {
                    //check if Number is bigger then 0 and the current number of product is smaller then Number
                    if (Number > 0 && cartList[i].Number < Number)
                    {
                        //Remove Number from number of product
                        cartList[i].Number -= Number;
                    }
                        //else if Number equals null or equals the current number of product
                    else if (Number == null || cartList[i].Number == Number)
                    {
                        //Remove all number of product
                        cartList.RemoveAt(i);
                    }
                }
            }
        }


        public void PrintCart()
        {
            for (int i = 0; i < cartList.Count; i++)
            {
                for (int j = 0; j < Parser.GetList.Count; j++)
                {
                    if (cartList[i].Productcode == Parser.GetList[j].ProductCode)
                    {
                        if (Parser.GetList. < 1024)
                        {
                            _capacity = Parser.GetList[j]..ToString() + "GB";
                            
                        }
                        else
                        {
                            double cap = Parser.GetList.Capacity / 1000;
                            cap = Math.Round(cap);
                            _capacity = cap.ToString() + "TB";
                        }

                        String numberofproduct = cartList[i].Number.ToString()+". ";
                        _show = numberofproduct + Parser.GetList[j]
                    }
                }
            }
        }

        //CheckOut will show whats in the cart and remove all items from the cardList
        public void CheckOut()
        {
            PrintCart();
            cartList.Clear();
        }


    }
}
