using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class LoadingManager : MonoBehaviour {
    
    public static string levelToLoad;

    public static float loadProgress;

    public static bool levelLoading;

    public static LoadingManager loadingManager;

    void Awake() {
    	loadingManager = FindObjectOfType<LoadingManager>();

    	// Move out of preload
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            levelToLoad = "Title";
            LoadingManager.LoadLevel();
        }
    }

    // ------------------------------ SET/GET ------------------------------ //
    public static void SetLevelToLoad(string levelName) {
    	levelToLoad = levelName;
    }

    public static string GetLevelToLoad() {
    	return levelToLoad;
    }

    public static float GetLoadProgress() {
    	return loadProgress;
    }

    public static void SetLevelLoading(bool isLoading) {
    	levelLoading = isLoading;
    }

    public static bool GetLevelLoading() {
    	return levelLoading;
    }


    // ------------------------------ LEVEL LOADING ------------------------------ //
    public static event Action SceneChange;

    public static void LoadLevel() {
    	PrefsManager.UpdatePrefs();
    	loadingManager.StartCoroutine(LoadSceneAsynchronously(levelToLoad));
    }

    // Load level with load screen
    private static IEnumerator LoadSceneAsynchronously(string levelName) {
        AsyncOperation levelLoad = SceneManager.LoadSceneAsync(levelName);

        SceneChange?.Invoke();

        while (!levelLoad.isDone) {
            loadProgress = Mathf.Clamp01(levelLoad.progress / 0.9f);
            //Debug.Log(levelName + " Load Progress: " + (loadProgress * 100) + "% ");
            
            yield return null;
        }
    }
}
