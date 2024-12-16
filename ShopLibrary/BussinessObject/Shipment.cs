using System;
using System.Collections.Generic;

namespace ShopLibrary.BussinessObject;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public int? OrderId { get; set; }

    public int? ShippingMethodId { get; set; }

    public string? TrackingNumber { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ShippedDate { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ShippingMethod? ShippingMethod { get; set; }
}
