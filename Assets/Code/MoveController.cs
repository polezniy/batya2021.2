using UnityEngine;

public class MoveController : MonoBehaviour
{
    public CharacterController characterController;
    public Transform groundChecker;
    public LayerMask groundMask;
    public float groundCheckRadius;
    public float movementSpeed = 20f;
    public float jumpStrength = 15f;
    public float gravity = -25f;

    bool onGround;
    float xMovement, yMovement;


    private void Update()
    {
        onGround = Physics.CheckSphere(groundChecker.position, groundCheckRadius, groundMask);
        if (onGround && yMovement < 0f) yMovement = -5f;

        if (Input.GetAxis("Jump") > 0 && onGround) yMovement = jumpStrength;

        xMovement = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 movementVector = new Vector3(xMovement, 0f, 0f);
        yMovement += gravity * Time.deltaTime;
        movementVector.y = yMovement;
        characterController.Move(movementVector * Time.deltaTime);


    }
}
