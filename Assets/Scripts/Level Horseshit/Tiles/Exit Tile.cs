using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitTile : MonoBehaviour, ITile
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            OnWalkOver(other.gameObject);
    }

    public void OnWalkOver(GameObject player)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().LoadNextLevel();
    }
}
