using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Level List")]
public class LevelList : ScriptableObject
{
    public int[] sceneBuildIndexes;
    public int currentScene = 0;

    private const string lastSavedLevelKey = "LEVEL_LEFT_OFF";
    public string LevelSavePlayerPrefsKey { get { return lastSavedLevelKey; } }

    public void LoadFirstLevel()
    {
        currentScene = 0;
        SceneManager.LoadScene(sceneBuildIndexes[currentScene]);
    }

    public void LoadNextLevel()
    {
        currentScene++;
        if (currentScene > sceneBuildIndexes.Length - 1)
            currentScene = sceneBuildIndexes.Length - 1;

        SceneManager.LoadSceneAsync(sceneBuildIndexes[currentScene]);
    }

    public void SaveCurrentLevelToPlayerPrefs()
    {
        PlayerPrefs.SetInt(lastSavedLevelKey, currentScene);
        PlayerPrefs.Save();
    }

    public int GetSavedLevelFromPlayerPrefs() //where the integer being returned is the build index of the saved scene.
    {
        if (PlayerPrefs.HasKey(lastSavedLevelKey) == true)
        {
            int savedIndex = PlayerPrefs.GetInt(lastSavedLevelKey, 0);
            return sceneBuildIndexes[savedIndex];
        }
        else
        {
            Debug.LogError("There is no value with the key, " + lastSavedLevelKey + " saved into player prefs! Perhaps it got accidentally deleted?");
            return 0;
        }
    }

    public void DeleteSavedLevel()
    {
        PlayerPrefs.DeleteKey(lastSavedLevelKey);
    }
}
