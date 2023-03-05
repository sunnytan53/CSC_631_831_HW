using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeedMultiplier = 10f;
    public float rotateSpeedMultiplier = 5f;
    public float gravityMultiplier = 5f;
    public float jumpMultiplier = 10f;

    private Vector3 move = new Vector3();

    void Start()
    {
        gravityMultiplier *= Physics.gravity.y;
    }

    void Update()
    {
        // use GetButton instead of GetButtonDown for continous pressing
        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            move.y = Mathf.Sqrt(jumpMultiplier * -gravityMultiplier);
        }

        // do not set y=0 when not moving for isGrounded check
        // NOTE: isGrounded is True only when last move collide
        move.y += gravityMultiplier * Time.deltaTime;
        move.x = Input.GetAxis("Horizontal") * moveSpeedMultiplier;
        move.z = Input.GetAxis("Vertical") * moveSpeedMultiplier;

        characterController.Move(move * Time.deltaTime);

        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotateSpeedMultiplier);
        //float xRotation = Mathf.Clamp(Input.GetAxis("Mouse Y"), -90, 90);
        //transform.Rotate(Vector3.left, xRotation * rotateSpeedMultiplier);
    }
}
