using UnityEngine;
using System.Collections;

public class ControllerTest : MonoBehaviour {

    private Vector3 movementVector;
    private CharacterController characterController;
    private float movementSpeed = 1;
    private float jumpPower = 2;
    private float gravity = 20;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        movementVector.x = Input.GetAxis("LeftJoystickX") * movementSpeed;
        movementVector.z = Input.GetAxis("LeftJoystickY") * -movementSpeed;

        if (characterController.isGrounded)
        {
            movementVector.y = 0;

            if (Input.GetButtonDown("A"))
            {
                movementVector.y = jumpPower;
            }
        }

        movementVector.y -= gravity * Time.deltaTime;

        characterController.Move(movementVector * Time.deltaTime);

        Debug.Log(Input.GetJoystickNames()[0]);
    }
}
