using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private Vector3 moveInput;
    private Rigidbody rb;
    public int speed;
    private PlayerGeneric playerData;
    public bool hasCharacter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerData = gameObject.GetComponent<PlayerGeneric>();
        transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        //This is test code to see if join works as should
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //speed = 0;
    }
    public void OnMovePerformed(InputAction.CallbackContext value)
    {
        moveInput = new Vector3(value.ReadValue<Vector2>().x, 0, value.ReadValue<Vector2>().y);
    }
    public void OnShootPerformed(InputAction.CallbackContext value)
    {
        Debug.Log("Shooting");
    }
    public void OnJoinElf(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds ElfSO to Player Generic
            if (PlayerJoin.Instance.elfJoined == false)
            {
                PlayerJoin.Instance.elfJoined = true;
                hasCharacter = true;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                speed = 3;
            }
        }
    }
    public void OnJoinWarrior(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds WarriorSO to Player Generic
            if (PlayerJoin.Instance.warriorJoined == false)
            {
                PlayerJoin.Instance.warriorJoined = true;
                hasCharacter = true;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                speed = 1;
            }
        }
    }
    public void OnJoinWizard(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds WizardSO to Player Generic
            if (PlayerJoin.Instance.wizardJoined == false)
            {
                PlayerJoin.Instance.wizardJoined = true;
                hasCharacter = true;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                speed = 1;
            }
        }
    }
    public void OnJoinValkyrie(InputAction.CallbackContext value)
    {
        if(hasCharacter == false)
        {
            //Adds ValkyrieSO to Player Generic
            if (PlayerJoin.Instance.valkyrieJoined == false)
            {
                PlayerJoin.Instance.valkyrieJoined = true;
                hasCharacter = true;
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                speed = 2;
            }
        }
    }
    private void FixedUpdate()
    {
        if(hasCharacter)
            rb.velocity = moveInput * speed;
    }
}
