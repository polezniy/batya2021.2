using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterActor : MonoBehaviour
{
    [Header("Entity")]
    public Entity entity;

    [Header("Entity")]
    public float enterDuration;

    bool inShelter = false;

    public bool InShelter => inShelter;


    public void Interact()
    {
        if (inShelter)
        {
            StartCoroutine(ExitShelter());
        }
        else
        {
            Shelter shelter = entity.CollisionHandler.GetFirstShelter();
            if (shelter != null) StartCoroutine(EnterShelter(shelter));
        }
    }


    public IEnumerator EnterShelter(Shelter shelter)
    {
        inShelter = true;
        entity.MoveController.enabled = false;
        LeanTween.cancelAll();
        LeanTween.moveLocalZ(gameObject, 7f, enterDuration);
        yield return new WaitForSeconds(enterDuration);
    }

    public IEnumerator ExitShelter()
    {
        LeanTween.cancelAll();
        LeanTween.moveLocalZ(gameObject, 0f, enterDuration);
        yield return new WaitForSeconds(enterDuration);
        entity.MoveController.enabled = true;
        inShelter = false;
    }
}
