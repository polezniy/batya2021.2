using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float maxHealth;
    [SerializeField] int dominationReward = 1;

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
        if (CompareTag("Enemy"))
        {
            GameData.current.domination += dominationReward;

        }


        Destroy(gameObject);
    }
}
