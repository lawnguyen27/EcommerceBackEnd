using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShopLibrary.BussinessObject;

public partial class ProductSize
{
    public int ProductId { get; set; }

    public int SizeId { get; set; }

    public int Quantity { get; set; }
    [JsonIgnore]
    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
