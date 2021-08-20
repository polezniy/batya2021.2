using System.Collections;
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

        StartCoroutine(HitAlgorithm());
    }

    IEnumerator HitAlgorithm()
    {
        // Сюда засунуть срабатывание анимации

        attackProcess = true;

        // Задержка для замаха
        yield return new WaitForSeconds(swingDelay);

        // Сюда засунуть срабатывание звука удара 

        colliders = Physics.OverlapSphere(hitTarget.position, 0.7f);

        // Удар происходит только по объектам с тегом "Enemy"
        foreach (Collider item in colliders)
        {
            Debug.Log("tag = " + item.tag);
            if (item.CompareTag("Enemy"))
            {
                Health health = item.GetComponent<Health>();
                if (health != null) health.Value -= damage;
            }
        }

        lastAttackTime = Time.time;
        attackProcess = false;
    }
}
