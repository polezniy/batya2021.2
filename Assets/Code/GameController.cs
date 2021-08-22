using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
