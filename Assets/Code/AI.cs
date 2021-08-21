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

    float horizontalMoving;
    public Entity target;
    Coroutine currentAlgorithm;
    int currentPatrolPointIndex;
    Transform currentPatrolPoint;
    const float tickTime = 0.1f;
    WaitForSeconds tick = new WaitForSeconds(tickTime);

    public float HorizontalMoving => horizontalMoving;


    private void Awake()
    {
        if (patrolPoints != null && patrolPoints.Length > 0) currentPatrolPoint = patrolPoints[0];
        DefineBehaviour();
    }


    void DefineBehaviour()
    {
        Forget();
        switch (enemyType)
        {
            case EnemyType.SENTRY:
                break;
            case EnemyType.STRONGSENTRY:
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

    public IEnumerator GoToPoint(Vector3 pos)
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
    }

    public IEnumerator Attack(Entity target)
    {
        while (true)
        {
            if (target == null) yield break;
            if (Mathf.Abs(currentPatrolPoint.position.x - transform.position.x) < 1f)
            {
                entity.AttackController.Hit();
            }
            if (target == null) yield break;
            if (target.transform.position.x - transform.position.x > 0.1f) horizontalMoving = 1f;
            if (target.transform.position.x - transform.position.x < -0.1f) horizontalMoving = -1f;
            yield return tick;
        }
    }


    IEnumerator SecuritySequence()
    {
        while (true)
        {
            if (target != null)
            {
                yield return StartCoroutine(Attack(target));
            }
            else
            {
                yield return StartCoroutine(GoToPoint(currentPatrolPoint.position));
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