using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float maxHealth;

    [Header("Info")]
    [SerializeField] float healthValue;

    private void Awake()
    {
        healthValue = maxHealth;
    }

    public float Value
    {
        get => healthValue;
        set
        {
            healthValue = value;
            if (healthValue <= 0f) Die();
        }
    }




    void Die()
    {
        Destroy(gameObject);
    }
}
