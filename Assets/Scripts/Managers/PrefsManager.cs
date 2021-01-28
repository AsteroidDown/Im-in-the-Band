using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrefsManager {

    // Slider Values
    public static float masterVolume;
    public static float cameraOffset;

    // Toggle Values
    public static bool DPADToggle;

    // Player Prefs that need to be updated
    public static void UpdatePrefs() {
        SaveSystem.SavePlayerPrefs();
        //LoadingManager.SceneChange() += UpdatePrefs;
        //Debug.Log("Master Volume: " + masterVolume + "\nCamera Offset: " + cameraOffset + "\nDPAD Toggle: " + DPADToggle);
    }

    // ------------------------------ GET / SET ------------------------------//
    public static void SetMasterVolume(float volume) => masterVolume = volume;

    public static void SetCameraOffset(float offset) => cameraOffset = offset;

    public static void SetDPADToggle(bool toggle) => DPADToggle = toggle;

    public static float GetMasterVolume() => masterVolume;

    public static float GetCameraOffset() => cameraOffset;

    public static bool GetDPADToggle() => DPADToggle;
    
    // ------------------------------ CLOSE GAME ------------------------------//
    private static void OnApplicationQuit() {
        UpdatePrefs();
    }
}
