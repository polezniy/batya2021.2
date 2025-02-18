﻿using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Objects")]
    public Transform hitTarget;                // вокруг этой координаты будет происходить проверка на наличие врагов

    [Header("Settings")]
    public float damage = 1f;
    public float attackDelay = 1f;
    public float swingDelay = 0.3f;

    bool attackProcess = false;
    float lastAttackTime;
    Collider[] colliders;


    public bool AttackProcess => attackProcess;


    public void Hit()
    {
        if (attackProcess || Time.time - lastAttackTime < attackDelay) return;

        StartCoroutine(HitAlgorithm("Enemy"));
    }

    public void HitPlayer()
    {
        if (attackProcess || Time.time - lastAttackTime < attackDelay) return;

        StartCoroutine(HitAlgorithm("Player"));
        GameData.current.findGameManager().GetComponent<AudioManager>().Play("Hurt");
    }

    IEnumerator HitAlgorithm(string targetTag)
    {
        // Сюда засунуть срабатывание анимации

        attackProcess = true;

        // Задержка для замаха
        yield return new WaitForSeconds(swingDelay);

        // Сюда засунуть срабатывание звука удара 
        GameData.current.findGameManager().GetComponent<AudioManager>().Play("Punch");
        colliders = Physics.OverlapSphere(hitTarget.position, 0.7f);

        // Удар происходит только по объектам с нужным тегом
        foreach (Collider item in colliders)
        {
            if (item.CompareTag(targetTag))
            {
                Health health = item.GetComponent<Health>();
                Debug.Log("target : " + targetTag);
                if (health != null) health.Value -= damage;
                
            }
        }

        lastAttackTime = Time.time;
        attackProcess = false;
    }
}
