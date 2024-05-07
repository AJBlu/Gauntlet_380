using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKey : Wall
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            OnPlayerCollide(other.gameObject);
    }
    public override void OnPlayerCollide(GameObject player)
    {
        //TODO: once player inventory is implemented

        //check if key is in inventory
        //take away key and destroy self if collided with
        if (player.GetComponent<PlayerInventory>().hasKey())
        {
            gameObject.SetActive(false);
        }

    }
}
