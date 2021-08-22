using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public Text health;
    public Text domination;

    public GameObject block;
    public Canvas gameOverCanvas;

    void Awake()
    {
        gameOverCanvas.enabled = false;
    }

    void Start()
    {
        GetComponent<AudioManager>().Play("korridor");

        // Находит нужный текст, если есть
        if (health == null || domination == null)
        {
            try
            {
                health = GameObject.Find("Health").GetComponent<Text>();
                domination = GameObject.Find("Domination").GetComponent<Text>();
            }
            catch
            {
                // Выдает сообщение если нет
                Debug.Log("Не получается обнаружить Health и Domination");
            }
        }
    }
    void Update()
    {
        // Обновляет текстовые показатели
        domination.text = "Domination: " + GameData.current.domination;
        health.text = "Health: " + GameData.current.health;

        // Уничтожает препятствие перед лестницей, когда игрок достиг 20 доминации
        if(GameData.current.domination >= 20)
        {
            Destroy(block);
        }

        if(GameData.current.health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameOverCanvas.enabled = true;
        gameOverCanvas.GetComponentInChildren<Button>().onClick.AddListener(restartScene);
    }

    void restartScene()
    {
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("newTestScene");
    }
}
