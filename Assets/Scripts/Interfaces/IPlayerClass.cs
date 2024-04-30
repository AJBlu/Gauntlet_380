using UnityEngine;

public interface IPlayerClass
{
    void assignPlayerAttributes();

    void OnFight(Collider collider);

    void OnShoot();

    void OnMagic();

    void OnMove();

}
