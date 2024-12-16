﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLibrary.BussinessObject;

namespace ShopAPI.Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryRequest : ControllerBase
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        public string urlImg {  get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}