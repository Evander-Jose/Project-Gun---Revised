using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public LevelList levelList;
    public Button button;
    private void Start()
    {
        if(PlayerPrefs.HasKey(levelList.LevelSavePlayerPrefsKey))
        {
            //If there is a save file, then make the button active, and subscribe a method to it:
            button.interactable = true;
            button.onClick.AddListener(LoadSavedLevel);
        } else
        {
            //if not, then it must have been deleted:
            button.interactable = false;
            button.onClick.RemoveAllListeners();
        }
    }

    private void LoadSavedLevel()
    {
        SceneManager.LoadScene(levelList.GetSavedLevelFromPlayerPrefs());
    }
}
