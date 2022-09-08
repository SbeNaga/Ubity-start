using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 20f;
    private CharacterController myCC;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movmentVector;
    private float myGravity = -10f;


    void Start()
    {
        myCC = GetComponent <CharacterController>(); 
    }

   
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadBob();

        camAnim.SetBool(name:"isWalking", isWalking);
    }

    void GetInput()
    {
        inputVector = new Vector3(x:Input.GetAxisRaw("Horizontal"), y:0f, z: Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movmentVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        myCC.Move(motion:movmentVector * Time.deltaTime);
    }
    
    void CheckForHeadBob()
    {
        if  (myCC.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

}
