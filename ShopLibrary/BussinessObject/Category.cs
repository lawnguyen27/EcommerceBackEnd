﻿using System;
using System.Collections.Generic;

namespace ShopLibrary.BussinessObject;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? ImgUrl { get; set; }

    public int? CategoryTypeId { get; set; }

    public virtual CategoryType? CategoryType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
