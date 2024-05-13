using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int _keys;
    public int _potions;
    private int _inventoryLimit = 12, _currentInventory = 0;

    public void addKey()
    {
        if(_currentInventory < _inventoryLimit)
        {
            _keys++;
            _currentInventory++;
        }
    }

    public void addPotion()
    {
        if (_currentInventory < _inventoryLimit)
        {
            _potions++;
            _currentInventory++;
        }
    }

    public bool hasPotion()
    {
        if(_potions > 0) {
            _potions--;
            return true;
        }

        return false;
    }

    public bool hasKey()
    {
        if(_keys > 0)
        {
            _keys--;
            return true;
        }

        return false;
    }
}
