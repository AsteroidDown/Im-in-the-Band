using UnityEngine;

// ------------------------------ Save Classes ------------------------------ //

// PlayerPrefs stores the preferences of the user
[System.Serializable]
public class PlayerPrefs {
    
    public float masterVolume;
    public float cameraOffset;
    public bool DPADHidden;

    public PlayerPrefs() {
    	masterVolume = PrefsManager.masterVolume;
    	cameraOffset = PrefsManager.cameraOffset;
    	DPADHidden = PrefsManager.DPADToggle;
    }
}