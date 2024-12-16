using System;
using System.Collections.Generic;

namespace ShopLibrary.BussinessObject;

public partial class ShippingMethod
{
    public int ShippingMethodId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Cost { get; set; }

    public string? EstimatedDeliveryTime { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
