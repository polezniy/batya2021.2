using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Загрузка следующего уровня при столкновении с игроком
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene("Level_2_test");
        }
    }
}
