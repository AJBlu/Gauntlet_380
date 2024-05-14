using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Fighter_Generic
{
    public override void attack(GameObject player)
    {
        base.attack(player);
        Destroy(this);
    }
}
