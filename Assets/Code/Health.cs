using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (healthStoresInGameData) GameData.current.health = (int)maxHealth;
        else healthValue = maxHealth;
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
                //Debug.Log("Now GameData.current.health = " + GameData.current.health);
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
        if (CompareTag("Player"))
        {
         
            // Проигрыш:
            // Включить анимацию смерти
            // Вывесит окно проигрыша
        }
        else 
        {
            GameData.current.domination += dominationReward;
            Destroy(gameObject);
        }
    }
}
