using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Level List")]
public class LevelList : ScriptableObject
{
    public int[] sceneBuildIndexes;
    public int currentScene = 0;

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(sceneBuildIndexes[currentScene]);
    }

    public void LoadNextLevel()
    {
        currentScene++;
        if (currentScene > sceneBuildIndexes.Length - 1)
            currentScene = sceneBuildIndexes.Length - 1;

        SceneManager.LoadSceneAsync(sceneBuildIndexes[currentScene]);
    }
}
