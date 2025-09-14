using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemPicker))]
public class ItemFinder : MonoBehaviour
{
   private ItemPicker _itemPicker;

    private void Awake()
    {
        _itemPicker = GetComponent<ItemPicker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IItem>(out IItem item))
            item.Pick(_itemPicker);
    }
}
