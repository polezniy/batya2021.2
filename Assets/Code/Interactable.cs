using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int domination;
    public bool used;

    public Sprite condition2;
    void Start()
    {
        used = false;
    }

    void Update()
    {
        if(used) // Меняет цвет объекта, если он уже был использован
        {
            GetComponentInChildren<SpriteRenderer>().sprite = condition2;
            //GetComponent<Transform>().Translate(-0.1f, -0.3f, 0f);
            Destroy(GetComponent<BoxCollider>());
            used = false;
        }
    }
}
