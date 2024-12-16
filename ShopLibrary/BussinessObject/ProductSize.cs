﻿using System;
using System.Collections.Generic;

namespace ShopLibrary.BussinessObject;

public partial class ProductSize
{
    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
