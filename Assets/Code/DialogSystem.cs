using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    // Singleton
    private static GameData _current;
    public static GameData current
    {
        get
        {
            if (_current == null)
            {
                _current = new GameData();
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
    public bool dialogState;
    public int currentDialog;
    public int currentPhrase;


    private void Awake()
    {
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
    }
}

[System.Serializable]
public class Dialog
{
    public List<GameObject> phrase;
}
