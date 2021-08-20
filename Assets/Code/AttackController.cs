using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Objects")]
    public Transform hitTarget;                // вокруг этой координаты будет происходить проверка на наличие врагов

    [Header("Settings")]
    public float attackDelay = 1f;


    public void Hit()
    {
       // colliders = Physics.OverlapSphere(hitTarget.position, 
    }
}
