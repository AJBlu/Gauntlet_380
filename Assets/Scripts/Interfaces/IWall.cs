using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IWall
{
    void OnPlayerCollide(GameObject player);
}
