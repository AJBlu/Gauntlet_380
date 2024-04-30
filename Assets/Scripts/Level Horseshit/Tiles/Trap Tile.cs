using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapTile : ITile
{
    GameObject[] walls;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            OnWalkOver(other.gameObject);
    }

    public void OnWalkOver(GameObject player)
    {
        foreach (var wall in walls)
        {
            wall.SetActive(false);
        }
    }

}
