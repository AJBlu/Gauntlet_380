using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerJoin : Singleton<PlayerJoin>
{
    public bool elfJoined;
    public bool warriorJoined;
    public bool wizardJoined;
    public bool valkyrieJoined;
    public PlayerSO[] playerClasses;
}
