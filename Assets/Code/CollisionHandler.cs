using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Settings")]
    public LayerMask shelterMask;


    public Shelter GetFirstShelter()
    {
        Collider[] colliders;

        colliders = Physics.OverlapSphere(transform.position, 0.3f, shelterMask);
        Debug.Log("colliders: " + colliders.Length);
        if (colliders != null && colliders.Length > 0)
            return colliders[0].GetComponent<Shelter>();
        else
            return null;
    }
}
