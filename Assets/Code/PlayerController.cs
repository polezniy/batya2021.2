using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    float horizontalInput;
    bool jump;

    public float HorizontalInput { get => horizontalInput; }
    public bool Jump { get => jump; set { jump = value; } }


    private void Update()
    {
        if (!entity.ShelterActor.InShelter)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetAxis("Jump") > 0) jump = true;
        }

        if (Input.GetKeyDown(KeyCode.F)) entity.ShelterActor.Interact();
    }
}

public delegate void SimpleEventHandler();
