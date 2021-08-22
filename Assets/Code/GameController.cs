using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(AudioManager))]
public class GameController : MonoBehaviour
{
    public Text health;
    public Text domination;

    public GameObject block;
    public Canvas gameOverCanvas;

    private float fixedDeltaTime;

    void Awake()
    {
        gameOverCanvas.enabled = false;
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Start()
    {
        // Receiive the scene
        // Appoint the music
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

        if(Input.GetKeyDown(KeyCode.F))
        {
            StopTime();
        }

        // Уничтожает препятствие перед лестницей, когда игрок достиг 20 доминации
        if(GameData.current.domination >= 20)
        {
            // Пробует найти препятствие
            try
            {
                Destroy(GameObject.Find("block"));
            }
            catch
            {
                Debug.Log("Не могу найти преграду");
            }
        }

        // Смерть игрока
        if(GameData.current.health <= 0)
        {
            gameOverCanvas.enabled = true;
            
            gameOverCanvas.GetComponentInChildren<Button>().onClick.AddListener(RestartScene);
            StopTime();
        }
    }

    void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("scene");
    }

    void StopTime()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1.0f;

        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
