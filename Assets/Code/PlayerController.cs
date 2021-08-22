using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool interaction;
    private GameObject target;
    CharacterController characterController;

    [Header("Entity")]
    public Entity entity;

    float horizontalInput;
    bool jump;
    public float pushForce;

    public float HorizontalInput { get => horizontalInput; }
    public bool Jump { get => jump; set { jump = value; } }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Взаимодействие с интерактивными объектами
        if (Input.GetMouseButtonDown(1) && interaction && target.GetComponent<Interactable>().used == false)
        {
            GameData.current.domination += target.GetComponent<Interactable>().domination;
            target.GetComponent<Interactable>().used = true;
            interaction = false;
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
            GameData.current.findGameManager().GetComponent<AudioManager>().Play("levelend");
            Destroy(other.gameObject);
            if (GameData.current.health < 3) GameData.current.health++;
            GameData.current.health = GameData.current.health;
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

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bam");
            GameData.current.health--;
            Vector3 dist = transform.position - other.transform.position;
            characterController.Move(dist * pushForce);
        }

        if (other.CompareTag("Trigger"))
        {
            GameData.current.findGameManager().GetComponent<AudioManager>().Play("bossfight");
        }
    }

    public delegate void SimpleEventHandler();
}