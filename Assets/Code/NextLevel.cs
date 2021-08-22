using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Загрузка следующего уровня при столкновении с игроком
        if (other.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().name == "Level_1")
            {
                SceneManager.LoadScene("Level_2");
            }

            if (SceneManager.GetActiveScene().name == "Level_2")
            {
                SceneManager.LoadScene("Level_3");
            }
        }
    }
}
