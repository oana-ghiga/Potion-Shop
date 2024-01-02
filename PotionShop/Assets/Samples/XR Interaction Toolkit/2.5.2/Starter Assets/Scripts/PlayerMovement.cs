using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;
        characterController.Move(movement * Time.deltaTime);
    }
}
