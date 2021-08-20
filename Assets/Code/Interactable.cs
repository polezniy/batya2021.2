using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int domination;
    public bool used;

    void Start()
    {
        used = false;
    }

    void Update()
    {
        if(used) // Меняет цвет объекта, если он уже был использован
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
