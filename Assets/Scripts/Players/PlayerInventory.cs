using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int _keys;
    public int _potions;

    public void addKey()
    {
        _keys++;
    }

    public void addPotion()
    {
        _potions++;
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
