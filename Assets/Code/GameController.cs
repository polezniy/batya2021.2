using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text health;
    public Text domination;

    public GameObject block;

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
    }
}
