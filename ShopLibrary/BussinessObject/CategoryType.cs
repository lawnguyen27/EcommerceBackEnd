using System;
using System.Collections.Generic;

namespace ShopLibrary.BussinessObject;

public partial class CategoryType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
