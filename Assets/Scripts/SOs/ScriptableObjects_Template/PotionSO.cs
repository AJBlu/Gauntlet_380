using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSO : ScriptableObject
{
    [SerializeField]
    Potions potion;

    [SerializeField]
    int Health = 1;
}
