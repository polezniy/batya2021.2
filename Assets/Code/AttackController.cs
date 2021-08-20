﻿using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Objects")]
    public Transform hitTarget;                // вокруг этой координаты будет происходить проверка на наличие врагов

    [Header("Settings")]
    public float attackDelay = 1f;


    Collider[] colliders;

    public void Hit()
    {
        // Сюда засунуть срабатывание звука удара

        colliders = Physics.OverlapSphere(hitTarget.position, 0.7f);

        // Удар происходит только по объектам с тегом "Enemy"
        foreach (Collider item in colliders)
        {
            Debug.Log("tag = " + item.tag);
            if (item.CompareTag("Enemy")) 
            {
                Health health = item.GetComponent<Health>();
                if (health != null) health.Value -= 1f; 
            }
        }
    }
}
