using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRMDataManager.Library.DataAccess;
using SRMDataManager.Library.Models;

namespace SRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")]
    public class ProductController : ControllerBase
    {        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();
            return data.GetProducts();
        }
    }
}
