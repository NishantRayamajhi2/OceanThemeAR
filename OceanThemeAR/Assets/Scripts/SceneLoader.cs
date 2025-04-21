using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("LoadScene called with sceneName: " + sceneName);

        // Check if the scene exists in Build Settings
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        bool sceneFound = false;
        int sceneIndex = -1;
        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameInBuild = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            Debug.Log("Scene at index " + i + ": " + sceneNameInBuild);
            if (sceneNameInBuild == sceneName)
            {
                sceneFound = true;
                sceneIndex = i;
                break;
            }
        }

        if (!sceneFound)
        {
            Debug.LogError("Scene " + sceneName + " not found in Build Settings!");
            return;
        }

        try
        {
            Debug.Log("Attempting to load scene: " + sceneName);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            Debug.Log("Scene " + sceneName + " load command issued");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load scene " + sceneName + ": " + e.Message);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
