using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IWall
{
    private void OnEnable()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

    }


 
    public virtual void OnPlayerCollide(GameObject player)
    {
        //nothing for generic wall
    }
}
