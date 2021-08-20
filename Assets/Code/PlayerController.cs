﻿using System.Collections;
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
        // Обновление статов игрока
        GameData.current.health = health;
        GameData.current.domination = domination;

        // Взаимодействие с интерактивными объектами
        if (Input.GetMouseButtonDown(1) && interaction && target.GetComponent<Interactable>().used == false)
        {
            domination += target.GetComponent<Interactable>().domination;
            target.GetComponent<Interactable>().used = true;
        }

        if (!entity.ShelterActor.InShelter)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if (Input.GetAxis("Jump") > 0) jump = true;
        }

        if (Input.GetKeyDown(KeyCode.F)) entity.ShelterActor.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthKit")) // Подбирание аптечки
        {
            Destroy(other.gameObject);
            if (health < 3) health++;
        }

        if (other.CompareTag("Interactable")) // Взаимодействие с объектами
        {
            interaction = true;
            target = other.gameObject;

        }
        else
        {
            interaction = false;
            Destroy(target);
        }
    }

    public delegate void SimpleEventHandler();
}