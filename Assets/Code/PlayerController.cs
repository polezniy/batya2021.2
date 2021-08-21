using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    private bool interaction;
    private GameObject target;

    public int domination;

    [Header("Entity")]
    public Entity entity;

    float horizontalInput;
    bool jump;

    public float HorizontalInput { get => horizontalInput; }
    public bool Jump { get => jump; set { jump = value; } }

    void Update()
    {

        // Взаимодействие с интерактивными объектами
        if (Input.GetMouseButtonDown(1) && interaction && target.GetComponent<Interactable>().used == false)
        {
            domination += target.GetComponent<Interactable>().domination;
            GameData.current.domination = domination;
            target.GetComponent<Interactable>().used = true;
        }

        if (!entity.ShelterActor.InShelter)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetAxis("Jump") > 0) jump = true;

            if (Input.GetMouseButtonDown(0)) entity.AttackController.Hit();
        }

        if (Input.GetKeyDown(KeyCode.F)) entity.ShelterActor.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthKit")) // Подбирание аптечки
        {
            Destroy(other.gameObject);
            if (health < 3) health++;
            GameData.current.health = health;
        }

        if (other.CompareTag("Interactable")) // Взаимодействие с объектами
        {
            interaction = true;
            target = other.gameObject;
        }
        else
        {
            interaction = false;
        }
    }

    public delegate void SimpleEventHandler();
}