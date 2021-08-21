using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player found");
            GetComponentInParent<AI>().target = other.GetComponent<Entity>();
        }
    }
}
