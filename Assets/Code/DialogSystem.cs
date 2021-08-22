using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour
{
    // Singleton
    private static DialogSystem _current;
    public static DialogSystem current
    {
        get
        {
            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
            }
        }
    }

    public GameObject endTitle;
    public List<Dialog> dialogs;
    public GameObject pressAnyKeyText;
    public bool dialogState;
    public int currentDialog;
    public int currentPhrase;
    bool lockPhraseSwitching;


    private void Awake()
    {
        if (_current == null)
        {
            _current = this;
        }

        if (SceneManager.GetActiveScene().name == "Level_1")
            TurnOnDialog(0);
    }

    private void Update()
    {
        if (dialogState)
        {
            if (!lockPhraseSwitching && Input.anyKeyDown)
            {
                NextPhrase();
            }
        }
    }


    public void TurnOnDialog(int index, int phraseIndex = 0)
    {
        Time.timeScale = 0f;
        dialogState = true;
        currentDialog = index;
        TurnOffAllElements();
        pressAnyKeyText.SetActive(true);
        StartCoroutine(LockPhraseSwitchingForTime(1f));
        if (phraseIndex == 0) currentPhrase = 0;
        dialogs[currentDialog].phrase[phraseIndex].SetActive(true);
    }

    public void TurnOffDialog()
    {
        dialogState = false;
        Time.timeScale = 1f;
        TurnOffAllElements();
    }

    public void NextPhrase()
    {
        if (currentPhrase == dialogs[currentDialog].phrase.Count - 1) TurnOffDialog();
        else TurnOnDialog(currentDialog, ++currentPhrase);
    }

    void TurnOffAllElements()
    {
        foreach (Dialog dialog in dialogs)
        {
            foreach (GameObject phrase in dialog.phrase)
            {
                phrase.SetActive(false);
            }
        }
        pressAnyKeyText.SetActive(false);
    }

    IEnumerator LockPhraseSwitchingForTime(float delay)
    {
        lockPhraseSwitching = true;
        yield return new WaitForSecondsRealtime(delay);
        Debug.Log("lockPhraseSwitching = false");
        lockPhraseSwitching = false;
    }

    public void TurnOnEndTitle()
    {
        endTitle.SetActive(true);
    }
}

[System.Serializable]
public class Dialog
{
    public List<GameObject> phrase;
}
