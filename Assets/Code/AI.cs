using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Settings")]
    [SerializeField] EnemyType enemyType;
    [SerializeField] Transform[] patrolPoints;

    [Header("Info")]
    float horizontalMoving;
    public Entity target;
    Coroutine currentAlgorithm;
    int currentPatrolPointIndex;
    Transform currentPatrolPoint;
    Vector3 spawnCoordinates;
    const float tickTime = 0.1f;
    WaitForSeconds tick = new WaitForSeconds(tickTime);

    public float HorizontalMoving => horizontalMoving;


    private void Awake()
    {
        if (patrolPoints != null && patrolPoints.Length > 0) currentPatrolPoint = patrolPoints[0];
        spawnCoordinates = transform.position;
        DefineBehaviour();
    }


    void DefineBehaviour()
    {
        Forget();
        switch (enemyType)
        {
            case EnemyType.SENTRY:
                currentAlgorithm = StartCoroutine(SentrySequence());
                break;
            case EnemyType.STRONGSENTRY:
                currentAlgorithm = StartCoroutine(StrongsentrySequence());
                break;
            case EnemyType.SECURITY:
                currentAlgorithm = StartCoroutine(SecuritySequence());
                break;

        }
    }

    void Forget()
    {
        StopAllCoroutines();
        target = null;
        horizontalMoving = 0f;
    }

    public void NextPatrolPoint()
    {
        if (currentPatrolPoint = null) currentPatrolPointIndex = 0;
        else if (currentPatrolPointIndex < patrolPoints.Length - 1) currentPatrolPointIndex++;
        else currentPatrolPointIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolPointIndex];
    }

/*    public IEnumerator GoToPoint(Vector3 pos)
    {
        while (true)
        {
            if (Mathf.Abs(currentPatrolPoint.position.x - transform.position.x) < 1f)
            {
                NextPatrolPoint();
                break;
            }
            if (pos.x - transform.position.x > 0.1f) horizontalMoving = 1f;
            if (pos.x - transform.position.x < -0.1f) horizontalMoving = -1f;
            yield return tick;
        }
    }*/

/*    public IEnumerator Attack(Entity target)
    {
        while (true)
        {
            if (target == null) yield break;
            if (target.ShelterActor.InShelter)
            {
                DefineBehaviour();
            }
            if (Mathf.Abs(currentPatrolPoint.position.x - transform.position.x) < 1f)
            {
                entity.AttackController.Hit();
            }
            if (target == null) yield break;
            if (target.transform.position.x - transform.position.x > 0.1f) horizontalMoving = 1f;
            if (target.transform.position.x - transform.position.x < -0.1f) horizontalMoving = -1f;
            yield return tick;
        }
    }*/


    IEnumerator SentrySequence()
    {
        Vector3 pos;

        while (true)
        {
            if (target != null)
            {
                if (target != null && target.ShelterActor.InShelter)
                {
                    DefineBehaviour();
                }
                if (target != null && Mathf.Abs(target.transform.position.x - transform.position.x) < 1.4f)
                {
                    entity.AttackController.HitPlayer();
                }
                if (target != null)
                {
                    if (target.transform.position.x - transform.position.x > 0.1f) horizontalMoving = 1f;
                    if (target.transform.position.x - transform.position.x < -0.1f) horizontalMoving = -1f;
                }
                yield return tick;
            }
            else
            {
                if (Mathf.Abs(spawnCoordinates.x - transform.position.x) > 1f)
                {
                    if (spawnCoordinates.x - transform.position.x > 0.5f) horizontalMoving = 1f;
                    if (spawnCoordinates.x - transform.position.x < -0.5f) horizontalMoving = -1f;
                }
                else horizontalMoving = 0f;
                yield return tick;
            }

            yield return tick;
        }
    }

    IEnumerator StrongsentrySequence()
    {
        Vector3 pos;

        while (true)
        {
            if (target != null)
            {
                if (target != null && target.ShelterActor.InShelter)
                {
                    DefineBehaviour();
                }
                if (target != null && Mathf.Abs(target.transform.position.x - transform.position.x) < 1.4f)
                {
                    entity.AttackController.HitPlayer();
                }
                if (target != null)
                {
                    if (target.transform.position.x - transform.position.x > 0.1f) horizontalMoving = 1f;
                    if (target.transform.position.x - transform.position.x < -0.1f) horizontalMoving = -1f;
                }
                yield return tick;
            }
            else
            {
                if (Mathf.Abs(spawnCoordinates.x - transform.position.x) > 1f)
                {
                    if (spawnCoordinates.x - transform.position.x > 0.5f) horizontalMoving = 1f;
                    if (spawnCoordinates.x - transform.position.x < -0.5f) horizontalMoving = -1f;
                }
                else horizontalMoving = 0f;
                yield return tick;
            }

            yield return tick;
        }
    }

    IEnumerator SecuritySequence()
    {
        Vector3 pos;

        while (true)
        {
            if (target != null)
            {
                if (target != null && target.ShelterActor.InShelter)
                {
                    DefineBehaviour();
                }
                if (target != null && Mathf.Abs(target.transform.position.x - transform.position.x) < 1.4f)
                {
                    entity.AttackController.HitPlayer();
                }
                if (target != null)
                {
                    if (target.transform.position.x - transform.position.x > 0.1f) horizontalMoving = 1f;
                    if (target.transform.position.x - transform.position.x < -0.1f) horizontalMoving = -1f;
                }
                yield return tick;
            }
            else
            {
                pos = currentPatrolPoint.position;
                if (Mathf.Abs(pos.x - transform.position.x) < 1f)
                {
                    NextPatrolPoint();
                }
                if (pos.x - transform.position.x > 0.5f) horizontalMoving = 1f;
                if (pos.x - transform.position.x < -0.5f) horizontalMoving = -1f;
                yield return tick;
            }

            yield return tick;
        }
    }
}

public enum EnemyType
{
    SENTRY,
    STRONGSENTRY,
    SECURITY
}