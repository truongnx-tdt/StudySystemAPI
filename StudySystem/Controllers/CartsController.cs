﻿// <copyright file="CartsController.cs" ownedby="Xuan Truong">
//  Copyright (c) XuanTruong. All rights reserved.
//  FileType: Visual CSharp source file
//  Created On: 29/09/2023
//  Last Modified On: 29/09/2023
//  Description: CartsController.cs
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudySystem.Application.Service;
using StudySystem.Application.Service.Interfaces;
using StudySystem.Data.Entites;
using StudySystem.Data.Models.Request;
using StudySystem.Data.Models.Response;
using StudySystem.Infrastructure.CommonConstant;
using static System.Net.Mime.MediaTypeNames;

namespace StudySystem.Controllers
{
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly ILogger<CartsController> _logger;
        private readonly ICartService _cartService;
        private readonly IWebHostEnvironment _environment;
        public CartsController(ILogger<CartsController> logger, ICartService cartService, IWebHostEnvironment environment)
        {
            _logger = logger;
            _cartService = cartService;
            _environment = environment;

        }
        /// <summary>
        /// UpdateCart
        /// api: "~/api/update-cart"
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost(Router.UpdateCart)]

        public async Task<ActionResult<StudySystemAPIResponse<object>>> UpdateCart(CartInsertRequestModel requestModel)
        {
            var rs = await _cartService.InsertOrUpdateCart(requestModel);
            return new StudySystemAPIResponse<object>(StatusCodes.Status200OK, new Response<object>(rs, new object()));
        }

        [HttpPut("~/api/calculate-total")]
        public async Task<ActionResult<StudySystemAPIResponse<object>>> UpdateQuantity(int quantity)
        {
            return new StudySystemAPIResponse<object>(StatusCodes.Status200OK, new Response<object>(true, new object()));
        }

        [HttpGet("~/api/get-cart")]
        public async Task<ActionResult<StudySystemAPIResponse<CartResponseModel>>> GetCart()
        {
            var rs = await _cartService.GetCart();
            string hosturl = $"{this.Request.Scheme}:/{this.Request.Host}{this.Request.PathBase}/Product/";
            if (rs != null)
            {
                foreach (var item in rs.CartData)
                {
                    item.ImagePath = hosturl + $"{item.ProductId}/" + item.ImagePath;
                }
            }

            return new StudySystemAPIResponse<CartResponseModel>(StatusCodes.Status200OK, new Response<CartResponseModel>(true, rs));
        }


        [NonAction]
        private string GetFilepath(string productId)
        {
            return _environment.WebRootPath + "\\product\\" + productId;
        }
    }
}
