using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShopLibrary.BussinessObject;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
    [JsonIgnore]
    public virtual Product Product { get; set; } = null!;
}
