using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool healthStoresInGameData;
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
        get
        {
            if (healthStoresInGameData) return GameData.current.health;
            else return healthValue;
        }
        set
        {
            if (healthStoresInGameData)
            {
                GameData.current.health = (int)value;
                if (GameData.current.health <= 0f) Die();
                // Экран смерти
            }
            else
            {
                healthValue = value;
                if (healthValue <= 0f) Die();
            }
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
