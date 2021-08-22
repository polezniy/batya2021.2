using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int domination;
    public bool used;

    public bool vase;
    public bool plakat;
    public bool botan;

    public Sprite condition2;
    void Start()
    {
        used = false;
    }

    void Update()
    {
        if(used) // Меняет цвет объекта, если он уже был использован
        {
            if (plakat || vase && used)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = condition2;
                if (vase)
                {
                    GameData.current.findGameManager().GetComponent<AudioManager>().Play("vasa");
                    used = false;
                } else
                {
                    GameData.current.findGameManager().GetComponent<AudioManager>().Play("plakat");
                    used = false;
                }

            }

            if(botan && used)
            {
                Debug.Log("Udar");
                transform.Rotate(0f,0f,90f);
                //transform.Translate(-1f, 0f, 0f);
                GameData.current.findGameManager().GetComponent<AudioManager>().Play("Punch");
                used = false;
            }
            //GetComponent<Transform>().Translate(-0.1f, -0.3f, 0f);
            Destroy(GetComponent<BoxCollider>());
            used = false;
        }
    }
}
