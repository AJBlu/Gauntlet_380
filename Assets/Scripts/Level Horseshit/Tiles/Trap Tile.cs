using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using Unity.VisualScripting;
using UnityEngine;

public class TrapTile : MonoBehaviour, ITile
{
    public GameObject[] walls;





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
