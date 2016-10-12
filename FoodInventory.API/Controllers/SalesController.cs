using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodInventory.Data;
using FoodInventory.Data.Models;

namespace FoodInventory.API.Controllers
{
    [RoutePrefix("api/Sales")]
    public class SalesController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        [HttpPost]
        public HttpResponseMessage Post([FromBody] FoodInventory.Data.Models.DTOs.SalesDTO productSold)
        {
            try
            {
                var messageToReturn = "";
                var productToEdit = _unitOfWork.ProductRepository.Get().Where(p => p.ID == productSold.ID).FirstOrDefault();
                if (productToEdit == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "The product (" + productSold.Name + ") with ID (" + productSold.ID + ") does not exist.");
                }
                else
                {
                    //Edit this product.
                    productSold.NumberOfUnits = productSold.NumberOfUnits;
                    productSold.SaleDate = DateTime.Now;
                    productSold.PaymentType = productSold.PaymentType;
                    _unitOfWork.SalesRepository.Sell(productSold);
                    _unitOfWork.Save();
                    messageToReturn = "Item Sold (" + productSold.Name + ") with ID (" + productSold.ID + ").";
                }


                return Request.CreateResponse(HttpStatusCode.OK, messageToReturn);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc.ToString());
            }
        }

    }
}