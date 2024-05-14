using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MiddleofPlayers : MonoBehaviour
{
    [SerializeField] private GameObject[] playerTransforms;
    private float _totalX;
    private float _totalY;
    private float _totalZ;
    private float _centerX;
    private float _centerZ;
    private float _distanceX;
    private float _distanceZ;
    private float _tempDistX;
    private float _tempDistZ;
    private int _lengthActive;
    private void Update()
    {
        if (playerTransforms.Length != 0)
        {
            //Sets the totals to 0 since this is constantly updating we don't want the total to keep being added to.
            _totalX = 0;
            _totalZ = 0;
            _lengthActive = 0;
            for (int i = 0; i < playerTransforms.Length; i++)
            {
                if(playerTransforms[i].GetComponent<PlayerController>().hasCharacter)
                {
                    _totalX += playerTransforms[i].transform.position.x;
                    _totalZ += playerTransforms[i].transform.position.z;
                    _lengthActive++;
                }
            }
            if(_lengthActive != 0)
            {
                //Calculated center of players by dividing thier position by amount of players
                _centerX = _totalX / _lengthActive;
                _centerZ = _totalZ / _lengthActive;
                //Calculates distance of players so that it can stop the middle from moving if players are to far from each other so that they can't attempt to leave each other
                for (int i = 0; i < playerTransforms.Length; i++)
                {
                    for (int j = i + 1; j < playerTransforms.Length; j++)
                    {
                        _tempDistX = Mathf.Abs(playerTransforms[j].transform.position.x - playerTransforms[i].transform.position.x);
                        if (_tempDistX > _distanceX)
                        {
                            _distanceX = _tempDistX;
                        }
                        _tempDistZ = Mathf.Abs(playerTransforms[j].transform.position.z - playerTransforms[i].transform.position.z);
                        if (_tempDistZ > _distanceZ)
                        {
                            _distanceZ = _tempDistZ;
                        }
                    }
                }
                //Distance may be changed later or made with a changable variable set to 10 for testing purposes.
                if (_distanceX < 10 && _distanceZ < 10)
                {
                    transform.position = new Vector3(_centerX, transform.position.y, _centerZ);
                }
                //If statements added to make more smooth transitions as otherwise moving in diagonals would cause it to hard cut
                if (_distanceX > 10 && _distanceZ < 10)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, _centerZ);
                }
                if (_distanceX < 10 && _distanceZ > 10)
                {
                    transform.position = new Vector3(_centerX, transform.position.y, transform.position.z);
                }
                //Sets distance to 0 as in update it will run through the for statements again to check the distance once more and allow the players to move if need be.
                _distanceX = 0;
                _distanceZ = 0;
            }
        }
    }
}
