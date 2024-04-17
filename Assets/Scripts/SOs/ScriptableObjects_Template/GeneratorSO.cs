using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSO : ScriptableObject
{
    [SerializeField]
    int points;

    [SerializeField]
    Rank rank;

    [SerializeField]
    [Range(1,3)]
    int health;
}
