using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItemState
{
    int Amount { get; set; }
    bool IsEquipped { get; set; }
}
