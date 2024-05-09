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
    private bool hasCharacter = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerData = gameObject.GetComponent<PlayerGeneric>();
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
        //Adds ElfSO to Player Generic
        if(hasCharacter == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            speed = 3;
            hasCharacter = true;
        }
    }
    public void OnJoinWarrior(InputAction.CallbackContext value)
    {
        //Adds WarriorSO to Player Generic
        if (hasCharacter == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            speed = 1;
            hasCharacter = true;
        }
    }
    public void OnJoinWizard(InputAction.CallbackContext value)
    {
        //Adds WizardSO to Player Generic
        if (hasCharacter == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            speed = 1;
            hasCharacter = true;
        }
    }
    public void OnJoinValkyrie(InputAction.CallbackContext value)
    {
        //Adds ValkyrieSO to Player Generic
        if (hasCharacter == false)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            speed = 2;
            hasCharacter = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }
}
