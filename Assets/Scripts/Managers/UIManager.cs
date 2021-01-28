using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    [Header("Loading")]
    public GameObject loadingScreen;
    public Slider loadingBar;
    private static string levelToLoad;

    [Header("HUD")]
    public GameObject HUD;
    public GameObject DPADButtons;
    
    [Header("Preference Adjustment")]
    public Slider masterVolume;
    public Slider cameraOffset;
    public Toggle DPADToggle;

    // ------------------------------ DATA GRAB ------------------------------ //
    void Awake() {

        // Create PlayerPrefs object for ggetting saved data
        PlayerPrefs data = SaveSystem.LoadPlayerPrefs();

        // Get saved data
        if (data == null) {
            // Make DPAD show by default
            DPADToggle.isOn = false;
            DPADHide(false);

            // Make master volume 1 by default
            masterVolume.value = 1f;
            MasterVolumeChange(1f);

            // Make camera offset 2 by default
            cameraOffset.value = 2f;

        } else {
            // Get DPAD hiding data
            DPADToggle.isOn = data.DPADHidden;
            DPADHide(data.DPADHidden);

            // Get master volume data
            masterVolume.value = data.masterVolume;
            MasterVolumeChange(data.masterVolume);

            // Get camera offset data
            cameraOffset.value = data.cameraOffset;
        }
    }


    // ------------------------------ LOAD CHECK ------------------------------ //
    void Update() {
        if (LoadingManager.GetLevelLoading()) {
            HUD.SetActive(false);
            LoadingManager.SetLevelLoading(false);
            UpdateUIPrefs();
            StartCoroutine(LoadLevel());
        }
    }


    // ------------------------------ PLAYER PREFS RELATED ------------------------------//
    // Hide and show the DPAD buttons
    public void DPADHide(bool hidden) {
        DPADButtons.SetActive(!hidden);
        PrefsManager.DPADToggle = hidden;
    }

    public void CameraOffsetChange(float offset) {
        PrefsManager.cameraOffset = offset;
    }

    // Change the master volume
    public void MasterVolumeChange(float newVolume) {
        AudioListener.volume = newVolume;
        PrefsManager.masterVolume = newVolume;
    }

    // Update slider and toggle values when changed externally
    public void UpdateUIPrefs() {
        DPADToggle.isOn = PrefsManager.GetDPADToggle();
        masterVolume.value = PrefsManager.GetMasterVolume();
        cameraOffset.value = PrefsManager.GetCameraOffset();
    }

    // ------------------------------ LEVEL LOADING ------------------------------//
    // Start loading a level
    public void StartLevelLoad() {
        LoadingManager.SetLevelLoading(true);
    }

    // Update levelToLoad
    public void LevelToLoadUpdate(string levelName) {
        LoadingManager.SetLevelToLoad(levelName);
    }

    // Load specific level
    public IEnumerator LoadLevel() {
        // Display loading screen and start to load level
        loadingScreen.SetActive(true);
        LoadingManager.LoadLevel();

        // Update loading bar value
        while (LoadingManager.GetLoadProgress() < 0.5f) {
            loadingBar.value = LoadingManager.GetLoadProgress();
            //Debug.Log(loadingBar.value + " " + LoadingManager.GetLoadProgress());
            yield return null;
        }

        // Hide loading screen (and hud if title) and set the timescale to 1
        loadingScreen.SetActive(false);
        if (LoadingManager.levelToLoad == "Title") HUD.SetActive(false);
        else HUD.SetActive(true);
        Time.timeScale = 1f;
    }
}
