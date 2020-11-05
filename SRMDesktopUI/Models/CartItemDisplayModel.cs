﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDesktopUI.Models
{
    public class CartItemDisplayModel : INotifyPropertyChanged
    {
        public ProductDisplayModel Product { get; set; }
        private int _quantityInCart;

        public int QuantityInCart
        {
            get { return _quantityInCart; }
            set 
            {
                _quantityInCart = value;
                CallPropertyChanged(nameof(QuantityInCart));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
