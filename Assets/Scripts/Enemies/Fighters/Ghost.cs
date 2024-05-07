using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy_Generic
{
    private void OnTriggerEnter(Collider other)
    {

        Destroy(this);

    }
}
