using System.Collections;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Objects")]
    public PlayerController playerController;
    public CharacterController characterController;
    public Transform groundChecker;
    public LayerMask groundMask;
    public GameObject model;             // Это дочерний объект самого префаба

    [Header("Settings")]
    public float groundCheckRadius;
    public float movementSpeed = 20f;
    public float jumpStrength = 15f;
    public float gravity = -25f;
    public bool controlByPlayer = true;

    bool onGround;
    float xMovement, yMovement;


    private void Awake()
    {
        StartCoroutine(AngleControl());
    }

    private void Update()
    {
        onGround = Physics.CheckSphere(groundChecker.position, groundCheckRadius, groundMask);
        if (onGround && yMovement < 0f) yMovement = -5f;

        if (controlByPlayer)
        {
            if (playerController.Jump)
            {
                if (onGround)
                    yMovement = jumpStrength;
                else
                    playerController.Jump = false;
            }
            xMovement = playerController.HorizontalInput * movementSpeed;
        }

        Vector3 movementVector = new Vector3(xMovement, 0f, 0f);
        yMovement += gravity * Time.deltaTime;
        movementVector.y = yMovement;
        characterController.Move(movementVector * Time.deltaTime);
    }

    IEnumerator AngleControl()
    {
        float delayTime = 0.1f;
        WaitForSeconds delay = new WaitForSeconds(delayTime);

        while(true)
        {
            // Поворот модельки влево или вправо в зависимости от направления движения
            LeanTween.rotateY(model, xMovement > 0f ? 1f : 179f, delayTime);
            yield return delay;
        }
    }
}
