using System;
using System.Collections.Generic;

namespace ShopLibrary.BussinessObject;

public partial class Size
{
    public int Id { get; set; }

    public string Size1 { get; set; } = null!;

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
