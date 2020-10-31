using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDataManager.Library.Models
{
    public class ProductModel
    {
        /// <summary>
        /// The Unique Identifier for each product.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name for the given Product
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// A description detailing information about the selected product.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The value or retail price of the product selected. (How much it sells for)
        /// </summary>
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// Number of available stock of the selected item.
        /// </summary>
        public int QuantityInStock { get; set; }

        public bool IsTaxable { get; set; }

    }
}
