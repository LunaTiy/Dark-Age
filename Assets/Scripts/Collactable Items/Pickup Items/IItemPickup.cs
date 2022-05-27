using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemPickup
{
    public IInventoryItemInfo Info { get; }
    public IInventoryItem Item { get; }
}
