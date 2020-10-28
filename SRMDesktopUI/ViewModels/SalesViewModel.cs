using Caliburn.Micro;
using SRMDesktopUi.Library.Api;
using SRMDesktopUi.Library.Models;
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
        IProductEndpoint _productEndpoint;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
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
