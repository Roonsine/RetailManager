using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set 
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;
        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }


        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            { 
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string SubTotal
        {
            // TODO - Replace with calculation
            get { return "$0.00"; }
        }
        public string Tax
        {
            // TODO - Replace with calculation
            get { return "$0.00"; }
        }
        public string Total
        {
            // TODO - Replace with calculation
            get { return "$0.00"; }
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                // make sure something is selected    
                return output;
            }
        }

        public void AddToCart()
        {
            
        }
        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                // make sure something is selected
                return output;
            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                // make sure there is something in the cart
                return output;
            }
        }

        public void CheckOut()
        {

        }
    }
}
