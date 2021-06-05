using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public Transform cam;
    private bool groundedPlayer;
    public float playerSpeed;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float turboSmoothtime = 0.1f;
    float turboSmoothVelocity;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Vertical")  , 0, -Input.GetAxis("Horizontal"));
        

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(-move.z, move.x) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turboSmoothVelocity, turboSmoothtime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
