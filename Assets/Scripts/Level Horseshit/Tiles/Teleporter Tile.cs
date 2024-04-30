using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterTile : ITile
{
    
    public GameObject destinationTile;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            OnWalkOver(other.gameObject);
    }

    public void OnWalkOver(GameObject player)
    {

        player.gameObject.transform.position = destinationTile.transform.position;
    }
}
