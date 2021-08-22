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
            if (_current == null)
            {
                _current = new DialogSystem();
            }
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

    public List<Dialog> dialogs;
    public GameObject pressAnyKeyText;
    public bool dialogState;
    public int currentDialog;
    public int currentPhrase;


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Level_1")
            TurnOnDialog(0);
    }

    private void Update()
    {
        if (dialogState)
        {
            if (Input.anyKeyDown)
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
}

[System.Serializable]
public class Dialog
{
    public List<GameObject> phrase;
}
